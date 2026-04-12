using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Entities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast;
using Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature
{
    public sealed class EnemiesEntityFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        private readonly CollidersRegistryService _collidersRegistryService;
        private readonly AbilityFactory _abilityFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly MainHeroHolderService _mainHeroHolderService;

        public EnemiesEntityFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
            _abilityFactory = _container.Resolve<AbilityFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _mainHeroHolderService = _container.Resolve<MainHeroHolderService>();
        }

        public Entity Create(EntityConfig config, Vector3 position)
        {
            Entity entity;

            switch (config)
            {
                case BaseCreepConfig baseCreepConfig:
                    entity = CreateBaseСreep(baseCreepConfig, position);

                    //Dictionary<AbilitySlotType, AbilityConfig> abilities = baseCreepConfig.GetAbilities();

                    //foreach (AbilitySlotType key in abilities.Keys)
                    //{
                    //    Entity ability = _abilityFactory.Create(abilities[key], entity);

                    //    entity.AbilityStorage.Add(key, ability);
                    //}

                    _brainsFactory.CreateBaseEnemyBrain(entity, new MainHeroTargetSelector(_mainHeroHolderService));
                    _entitiesLifeContext.Add(entity);
                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config!");
            }
            return entity;
        }

        private Entity CreateBaseСreep(BaseCreepConfig config, Vector3 position)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, config.PathToPrefab);

            entity
                .AddInputMovementDirection()
                .AddMovementDirection()
                .AddMovementSpeed(new ReactiveVariable<float>(config.MovementSpeed))
                .AddIsMoving()
                .AddRotationDirection()
                .AddTargetRotation()
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddIsDead()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddTeam(new ReactiveVariable<TeamType>(config.Team))
                .AddCurrentTarget()
                .AddShouldForceDeath()
                .AddAbilityStorage(new Dictionary<AbilitySlotType, Entity>())
                .AddAbilityCurrent(new ReactiveVariable<AbilitySlotType>(AbilitySlotType.Main))
                .AddAbilityCastInProcess();

            Dictionary<AbilitySlotType, AbilityConfig> abilities = config.GetAbilities();

            foreach (AbilitySlotType key in abilities.Keys)
            {
                Entity ability = _abilityFactory.Create(abilities[key], entity);

                entity.AbilityStorage.Add(key, ability);
            }

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotateToMousePosition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0))
                .Add(new FuncCondition(() => entity.ShouldForceDeath.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canSpawnExplosion = new CompositeCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.ExplosionRequested.Value));

            ICompositeCondition canUseAbilities = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotateToMousePosition)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanCastAbility(canUseAbilities);

            entity
                .AddSystem(new MovementDirectionResolveSystem())
                .AddSystem(new TransformMovementAppliedSystem())
                .AddSystem(new MovementRotationDirectionUpdateSystem())
                .AddSystem(new LookRotationSystem())
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new AbilityCastStartSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }
    }
}