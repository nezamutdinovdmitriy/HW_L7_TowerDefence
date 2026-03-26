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
        private readonly CombatEntityFactory _combatEntityFactory;
        private readonly WalletService _walletService;

        private readonly IGameplayInputService _inputService;

        public MainHeroEntityFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _combatEntityFactory = _container.Resolve<CombatEntityFactory>();
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
                .AddRotationSpeed(new ReactiveVariable<float>(towerConfig.RotationSpeed))
                .AddAimPoint()
                .AddIsDead()
                .AddInDeathProcess()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddTeam(new ReactiveVariable<TeamType>(TeamType.MainHero))
                .AddAbilityCurrent(new ReactiveVariable<AbilityType>(AbilityType.Main))
                .AddArcaneMineUseRequest()
                .AddArcaneMineUseEvent()
                .AddArcaneMineCost(new ReactiveVariable<int>(towerConfig.UtilityAbilityCost))
                .AddFireballUseRequest()
                .AddAbilityStorage(new Dictionary<AbilityType, ReactiveEvent> {
                    { AbilityType.Main, entity.FireballUseRequest },
                    { AbilityType.Utility, entity.ArcaneMineUseRequest }
                });

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

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanRotate(canRotateToMousePosition)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanUseArcaneMine(canUseArcaneMine)
                .AddCanUseFireball(canUseFireball);

            entity
                .AddSystem(new MouseRotationDirectionUpdateSystem(
                    _container.Resolve<ScreenToWorldPositionConverter>(),
                    _inputService))
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new AbilityUseSystem(_inputService))
                .AddSystem(new ArcaneMineSystem(_combatEntityFactory))
                .AddSystem(new ArcaneMineGoldCostSystem(_walletService))
                .AddSystem(new FireballSystem(_combatEntityFactory))
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}