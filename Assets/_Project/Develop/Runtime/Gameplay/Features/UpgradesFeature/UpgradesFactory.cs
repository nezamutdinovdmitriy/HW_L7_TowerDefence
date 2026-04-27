using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.TowerHealOnWaveStart;
using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature
{
    public class UpgradesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _lifeContext;
        private readonly UpgradeEffectsContainerConfig _configs;
        private readonly StageProvider _stageProvider;

        public UpgradesFactory(
            DIContainer container,
            EntitiesLifeContext lifeContext)
        {
            _container = container;
            _lifeContext = lifeContext;
            _configs = _container.Resolve<ConfigsProvider>().GetConfig<UpgradeEffectsContainerConfig>();
            _stageProvider = _container.Resolve<StageProvider>();
        }

        public Entity Create(Entity owner, UpgradeType upgradeType)
        {
            Entity upgrade = CreateCommon(owner);
            var config = _configs.GetConfigBy(upgradeType);

            switch (config)
            {
                case TowerHealConfig towerHealConfig:
                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag()
                        .AddIsEffectApplied()
                        .AddHealPercent(new(towerHealConfig.HealPercent));

                    ICompositeCondition canApplyEffect = new CompositeCondition()
                        .Add(new FuncCondition(() =>
                        {
                            if (_stageProvider.CurrentStageResult.Value != StageResult.Uncompleted)
                                return false;

                            if (_stageProvider.CurrentStageNumber.Value <= 1)
                                return false;

                            return true;
                        }));

                    ICompositeCondition canFinalizeEffect = new CompositeCondition()
                        .Add(new FuncCondition(() =>
                        {
                            return upgrade.IsEffectApplied.Value
                            && _stageProvider.CurrentStageResult.Value == StageResult.Completed;
                        }));

                    upgrade
                        .AddCanApplyEffect(canApplyEffect)
                        .AddCanFinalizeEffect(canFinalizeEffect)
                        .AddSystem(new TowerHealApplySystem())
                        .AddSystem(new EffectFinalizeSystem());

                    break;

                case FireballDamageMultiplierConfig fireballDamageMultiplierConfig:
                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();

                    break;

                case DamageFirstTargetsConfig damageFirstTargetsConfig:
                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();

                    break;

                default:
                    throw new Exception($"Unsupported upgrade {config}");
            }

            _lifeContext.Add(upgrade);

            return upgrade;
        }

        private Entity CreateCommon(Entity owner)
        {
            Entity upgrade = new();
            upgrade.Hierarchy.Value.SetParent(owner);
            return upgrade;
        }
    }
}