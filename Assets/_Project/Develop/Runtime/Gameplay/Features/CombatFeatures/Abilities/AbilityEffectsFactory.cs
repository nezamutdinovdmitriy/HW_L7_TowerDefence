using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
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

        public Entity CreateRuneTotem(Entity owner, RuneTotemAbilityConfig config)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, owner.InputAimPoint.Value, config.BaseConfig.PathToPrefab);

            entity
                .AddCurrentTarget()
                .AddRotationDirection()
                .AddTargetRotation()
                .AddRotationSpeed(new ReactiveVariable<float>(config.BaseConfig.RotationSpeed))
                .AddInputAimPoint()
                .AddIsDead()
                .AddTeam(new(owner.Team.Value))
                .AddAbilitySlotCurrent(new ReactiveVariable<AbilitySlotType>(AbilitySlotType.Main))
                .AddAbilitiesEquipped(new Dictionary<AbilitySlotType, Entity>())
                .AddShouldForceDeath()
                .AddAbilityCastInProcess()
                .AddCurrentCastingAbility()
                .AddAbilityCastKeyMapping(_container.Resolve<ConfigsProvider>().GetConfig<AbilityToAnimatorKeyMapping>())
                .AddShouldCastAbility()
                .AddAttackRange(new(config.AttackRange));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.ShouldForceDeath.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canUseAbilities = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.AbilityCastInProcess.Value == false))
                .Add(new FuncCondition(() =>
                {
                    if (entity.CurrentTarget.Value == null)
                        return false;

                    if ((entity.CurrentTarget.Value.Transfrom.position - entity.Transfrom.position).magnitude >= entity.AttackRange.Value)
                        return false;

                    return true;
                }));

            ICompositeCondition canRotateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanRotate(canRotateCondition)
                .AddCanCastAbility(canUseAbilities);

            entity
                .AddSystem(new LookRotationSystem())
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new AbilityCastStartSystem(_container.Resolve<WalletService>()))
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            Dictionary<AbilitySlotType, AbilityConfig> abilities = config.BaseConfig.GetAbilities();

            foreach (AbilitySlotType key in abilities.Keys)
            {
                Entity ability = _container.Resolve<AbilityFactory>().Create(abilities[key], entity);

                entity.AbilitiesEquipped.Add(key, ability);
            }

            _container.Resolve<BrainsFactory>().CreateRuneTotemBrain(entity, new NearestDamageableTargetSelector(entity));

            return entity;
        }

        public Entity CreateToxicPuddle(Entity owner, ToxicPuddleAbilityConfig config)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, owner.InputAimPoint.Value, config.PrefabPath);

            entity
                .AddIsDead()
                .AddTeam(new(owner.Team.Value))
                .AddContactsCollidersBuffer(new(64))
                .AddContactsEntitiesBuffer(new(64))
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskCharacters)
                .AddIsTouchAnotherTeam()
                .AddDamageTick(new(config.DamagePerTick))
                .AddCooldownTick(new(config.CooldownTick))
                .AddToxicPuddleRadius(new(config.Radius))
                .AddAreaContactDetectingRadius(new(config.Radius))
                .AddShouldForceDeath()
                .AddContactsEntityTimers(new());

            //ICompositeCondition mustDieCindition = new CompositeCondition()
            //    .Add(new FuncCondition(() =>
            //    {
            //        StageProvider stageProvider = _container.Resolve<StageProvider>();

            //        if (stageProvider.CurrentStageResult.Value == StageResult.Completed)
            //            return true;

            //        return false;
            //    }));

            ICompositeCondition mustDieCindition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.ShouldForceDeath.Value));

            ICompositeCondition mustSelfReleaseCondition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canStartDetectingCondition = new CompositeCondition()
                .Add(new FuncCondition(() => true));

            entity
                .AddMustDie(mustDieCindition)
                .AddCanStartDetecting(canStartDetectingCondition)
                .AddMustSelfRelease(mustSelfReleaseCondition);

            entity
                .AddSystem(new AreaContactDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new ContactDurationSystem())
                .AddSystem(new PeriodicDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateFireBall(Entity owner, Entity sourceAbility, FireballAbilityConfig config)
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
                .AddContactsDetectingMask(UnityLayersAPI.LayerMaskEnvironment | UnityLayersAPI.LayerMaskCharacters)
                .AddDeathMask(UnityLayersAPI.LayerMaskEnvironment)
                .AddExplosionRequested()
                .AddShouldForceDeath();

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value))
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            ICompositeCondition shouldExplosion = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustSelfRelease(mustSelfRelease)
                .AddMustDie(mustDie)
                .AddCanSpawnExplosion(shouldExplosion);

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
                .AddSystem(new ExplosionSpawnSystem(this, sourceAbility, config.ExplosionConfig))
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateArcaneMine(Entity owner, Entity sourceAbility, ArcaneMineAbilityConfig config)
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
                .AddShouldForceDeath();

            ICompositeCondition canStartDetecting = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition shouldExplosion = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanStartDetecting(canStartDetecting)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanSpawnExplosion(shouldExplosion);

            entity
                .AddSystem(new AreaContactDetectingSystem())
                .AddSystem(new SelfContactFilterSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new ExplosionSpawnSystem(this, sourceAbility, config.ExplosionConfig))
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateExplosion(Vector3 position, Entity owner, Entity sourceAbility, ExplosionConfig config)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, config.PrefabPath);

            float damage = config.ExplosionDamage;

            if (sourceAbility.HasComponent<AbilityDamageMultiplier>())
                damage *= sourceAbility.AbilityDamageMultiplier.Value;

            Debug.Log($"Есть ли модификатор: {sourceAbility.HasComponent<AbilityDamageMultiplier>()}");
            Debug.Log($"ДАМАГ = {damage}");

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
                .AddContactDamage(new ReactiveVariable<float>(damage))
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