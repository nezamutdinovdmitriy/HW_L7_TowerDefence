using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Entities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature
{
    public sealed class MainHeroEntityFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        private readonly AbilityFactory _abilityFactory;
        private readonly WalletService _walletService;

        private readonly IGameplayInputService _inputService;

        public MainHeroEntityFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _abilityFactory = _container.Resolve<AbilityFactory>();
            _inputService = _container.Resolve<IGameplayInputService>();
            _walletService = _container.Resolve<WalletService>();
        }

        public Entity CreateTower(BaseTowerConfig towerConfig, LevelConfig levelConfig)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, levelConfig.TowerSpawnPosition, towerConfig.PathToPrefab);

            entity
                .AddIsMainHero()
                .AddMaxHealth(new ReactiveVariable<float>(levelConfig.TowerMaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(levelConfig.TowerMaxHealth))
                .AddRotationDirection()
                .AddTargetRotation()
                .AddRotationSpeed(new ReactiveVariable<float>(towerConfig.RotationSpeed))
                .AddAimPoint()
                .AddIsDead()
                .AddInDeathProcess()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddTeam(new ReactiveVariable<TeamType>(TeamType.MainHero))
                .AddAbilityCurrent(new ReactiveVariable<AbilityType>(AbilityType.Main))
                .AddAbilityStorage(new Dictionary<AbilityType, Entity>());

            Dictionary<AbilityType, AbilityConfig> abilities = towerConfig.GetAbilities();

            foreach (AbilityType key in abilities.Keys)
            {
                Entity ability = _abilityFactory.Create(abilities[key], entity);

                entity.AbilityStorage.Add(key, ability);
            }

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canRotateToMousePosition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canUseArcaneMine = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => _walletService.Enough(CurrencyType.Gold, entity.ArcaneMineCost.Value)));

            ICompositeCondition canUseFireball = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canUseAbilities = new CompositeCondition()
                .Add(new FuncCondition(() => _inputService.IsShooting));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanRotate(canRotateToMousePosition)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanUseArcaneMine(canUseArcaneMine)
                .AddCanUseFireball(canUseFireball)
                .AddAbilityCanUse(canUseAbilities);

            entity
                .AddSystem(new MouseRotationDirectionUpdateSystem(
                    _container.Resolve<ScreenToWorldPositionConverter>(),
                    _inputService))
                .AddSystem(new LookRotationSystem())
                .AddSystem(new RotationClampSystem(30f))
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new AbilityUseSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}