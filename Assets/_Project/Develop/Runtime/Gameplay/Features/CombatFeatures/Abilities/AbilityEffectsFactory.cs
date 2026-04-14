using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public sealed class AbilityEffectsFactory
    {
        private readonly DIContainer _container;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly CollidersRegistryService _collidersRegistryService;

        public AbilityEffectsFactory(DIContainer container)
        {
            _container = container;
            _monoEntitiesFactory = container.Resolve<MonoEntitiesFactory>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
            _collidersRegistryService = container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateFireBall(Entity owner, FireballAbilityConfig config)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, owner.ShootPoint.position, config.ProjectileConfig.PrefabPath, owner.ShootPoint.rotation);

            Vector3 direction = (owner.InputAimPoint.Value - owner.ShootPoint.position).normalized;

            entity
                .AddInputMovementDirection(new ReactiveVariable<Vector3>(direction))
                .AddMovementDirection()
                .AddMovementSpeed(new ReactiveVariable<float>(config.ProjectileConfig.ProjectileSpeed))
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddTargetRotation()
                .AddRotationSpeed(new ReactiveVariable<float>(config.ProjectileConfig.ProjectileRotationSpeed))
                .AddIsMoving()
                .AddIsDead()
                .AddContactsCollidersBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddIsTouchDeathMask()
                .AddTeam(new ReactiveVariable<TeamsFeature.TeamType>(owner.Team.Value))
                .AddIsTouchAnotherTeam()
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskEnvironment)
                .AddDeathMask(UnityLayersAPI.LayerMaskEnvironment)
                .AddExplosionRequested()
                .AddShouldForceDeath()
                .AddShouldSpawnEffect();

            entity.IsDead.Subscribe((oldValue, newValue) =>
            {
                if(newValue == true)
                    entity.ShouldSpawnEffect.Value = true;
            });

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value))
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustSelfRelease(mustSelfRelease)
                .AddMustDie(mustDie);

            entity
                .AddSystem(new MovementDirectionResolveSystem())
                .AddSystem(new TransformMovementAppliedSystem())
                .AddSystem(new MovementRotationDirectionUpdateSystem())
                .AddSystem(new LookRotationSystem())
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new BodyContactDetectingSystem())
                .AddSystem(new SelfContactFilterSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new ExplosionSpawnSystem(this, config.ExplosionConfig))
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateArcaneMine(Entity owner, ArcaneMineAbilityConfig config)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, owner.InputAimPoint.Value, config.PrefabPath);

            entity
                .AddIsDead()
                .AddContactsCollidersBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskCharacters)
                .AddAreaContactDetectingRadius(new ReactiveVariable<float>(config.ActivationRadius))
                .AddTeam(new ReactiveVariable<TeamsFeature.TeamType>(owner.Team.Value))
                .AddIsTouchAnotherTeam()
                .AddShouldForceDeath()
                .AddShouldSpawnEffect();

            ICompositeCondition canStartDetecting = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity.IsDead.Subscribe((oldValue, newValue) =>
            {
                if (newValue == true)
                    entity.ShouldSpawnEffect.Value = true;
            });

            entity
                .AddCanStartDetecting(canStartDetecting)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new AreaContactDetectingSystem())
                .AddSystem(new SelfContactFilterSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new ExplosionSpawnSystem(this, config.ExplosionConfig))
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateExplosion(Vector3 position, Entity owner, ExplosionConfig config)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, config.PrefabPath);

            entity
                .AddIsDead()
                .AddContactsCollidersBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddIsTouchDeathMask()
                .AddTeam(new ReactiveVariable<TeamsFeature.TeamType>(owner.Team.Value))
                .AddIsTouchAnotherTeam()
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskCharacters)
                .AddDeathMask(UnityLayersAPI.LayerMaskCharacters)
                .AddAreaContactDetectingRadius(new ReactiveVariable<float>(config.ExplosionRadius))
                .AddExplosionRadius(new ReactiveVariable<float>(config.ExplosionRadius))
                .AddExplosionLifetime(new ReactiveVariable<float>(0.5f))
                .AddContactDamage(new ReactiveVariable<float>(config.ExplosionDamage))
                .AddShouldForceDeath();

            ICompositeCondition canStartDetecting = new CompositeCondition()
                .Add(new FuncCondition(() => entity.ExplosionLifetime.Value > 0));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.ExplosionLifetime.Value <= 0))
                .Add(new FuncCondition(() => entity.ShouldForceDeath.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanStartDetecting(canStartDetecting)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new AreaContactDetectingSystem())
                .AddSystem(new ExplosionLifetimeSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new TakeDamageSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}