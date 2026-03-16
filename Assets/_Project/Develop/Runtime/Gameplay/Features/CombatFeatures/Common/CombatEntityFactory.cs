using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Explosion;
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

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public sealed class CombatEntityFactory
    {
        private DIContainer _container;

        private MonoEntitiesFactory _monoEntitiesFactory;

        private EntitiesLifeContext _entitiesLifeContext;

        private CollidersRegistryService _collidersRegistryService;

        public CombatEntityFactory(DIContainer container)
        {
            _container = container;
            _monoEntitiesFactory = container.Resolve<MonoEntitiesFactory>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
            _collidersRegistryService = container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateFireBall(Vector3 position, Vector3 direction, Entity owner)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/Fireball");

            entity
                .AddInputMovementDirection(new ReactiveVariable<Vector3>(direction))
                .AddMovementDirection()
                .AddMovementSpeed(new ReactiveVariable<float>(25))
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(900))
                .AddIsMoving()
                .AddIsDead()
                .AddContactsCollidersBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddIsTouchDeathMask()
                .AddTeam(new ReactiveVariable<TeamsFeature.TeamType>(owner.Team.Value))
                .AddIsTouchAnotherTeam()
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskEnvironment)
                .AddDeathMask(UnityLayersAPI.LayerMaskEnvironment);

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
                .AddMustDie(mustDie)
                .AddCanSpawnExplosion(mustSelfRelease);

            entity
                .AddSystem(new MovementDirectionResolveSystem())
                .AddSystem(new TransformMovementAppliedSystem())
                .AddSystem(new MovementRotationDirectionUpdateSystem())
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new BodyContactDetectingSystem())
                .AddSystem(new SelfContactFilterSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new ExplosionSpawnSystem(this, 5f))
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateArcaneMine(Vector3 position, float activationRadius, float explosionRadius, Entity owner)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/Mine");

            entity
                .AddIsDead()
                .AddContactsCollidersBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskCharacters)
                .AddAreaContactDetectingRadius(new ReactiveVariable<float>(activationRadius))
                .AddTeam(new ReactiveVariable<TeamsFeature.TeamType>(owner.Team.Value))
                .AddIsTouchAnotherTeam();

            ICompositeCondition canStartDetecting = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canSpawnExplosion = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanStartDetecting(canStartDetecting)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanSpawnExplosion(canSpawnExplosion);

            entity
                .AddSystem(new AreaContactDetectingSystem())
                .AddSystem(new SelfContactFilterSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new ExplosionSpawnSystem(this, explosionRadius))
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateExplosion(Vector3 position, float radius, Entity owner)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/ExplosionEffect");

            ParticleSystem.ShapeModule particleShape = monoEntity.gameObject.GetComponent<ParticleSystem>().shape;
            particleShape.radius = radius;

            entity
                .AddIsDead()
                .AddContactsCollidersBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddIsTouchDeathMask()
                .AddTeam(new ReactiveVariable<TeamsFeature.TeamType>(owner.Team.Value))
                .AddIsTouchAnotherTeam()
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskCharacters)
                .AddDeathMask(UnityLayersAPI.LayerMaskCharacters)
                .AddAreaContactDetectingRadius(new ReactiveVariable<float>(radius))
                .AddExplosionInProcess()
                .AddExplosionDestroyDelay(new ReactiveVariable<float>(0.5f))
                .AddContactDamage(new ReactiveVariable<float>(50));

            ICompositeCondition canStartDetecting = new CompositeCondition()
                .Add(new FuncCondition(() => entity.ExplosionInProcess.Value == true));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.ExplosionDestroyDelay.Value <= 0));

            entity
                .AddCanStartDetecting(canStartDetecting)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new ExplosionStartSystem())
                .AddSystem(new AreaContactDetectingSystem())
                .AddSystem(new ExplosionEndSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new TakeDamageSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}