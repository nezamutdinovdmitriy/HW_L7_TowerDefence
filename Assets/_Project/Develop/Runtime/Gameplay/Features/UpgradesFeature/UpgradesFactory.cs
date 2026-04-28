using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.DamageFirstEnemies;
using Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.FireballDamageMultiplier;
using Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.TowerHealOnWaveStart;
using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using System;
using UnityEngine;

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
            UpgradeEffectConfig config = _configs.GetConfigBy(upgradeType);

            switch (config)
            {
                case TowerHealConfig towerHealConfig:
                    SetupTowerHealUpgrade(upgrade, towerHealConfig);
                    Debug.Log($"Добавлен апгрейд хила башни на {towerHealConfig.HealPercent}%");
                    break;

                case FireballDamageMultiplierConfig fireballDamageMultiplierConfig:
                    SetupFireballDamageMultiplierUpgrade(upgrade, fireballDamageMultiplierConfig);
                    Debug.Log($"Добавлен апгрейд увеличения урона от фаербола на x{fireballDamageMultiplierConfig.Multiplier}");
                    break;

                case DamageFirstTargetsConfig damageFirstTargetsConfig:
                    SetupDamageFirstTargetsUpgrade(upgrade, damageFirstTargetsConfig);
                    Debug.Log($"Добавлен апгрейд нанесения урона первым {damageFirstTargetsConfig.EnemiesCount} врагам. Урон {damageFirstTargetsConfig.DamagePercent}%");
                    break;

                default:
                    throw new Exception($"Unsupported upgrade {config}");
            }

            _lifeContext.Add(upgrade);

            return upgrade;
        }

        private void SetupDamageFirstTargetsUpgrade(Entity upgrade, DamageFirstTargetsConfig config)
        {
            upgrade
                .AddTowerHealOnWaveStartUpgradeTag()
                .AddIsEffectApplied()
                .AddPercent(new(config.DamagePercent));

            ICompositeCondition canApplyEffect = new CompositeCondition()
                .Add(new FuncCondition(() =>
                {
                    if (_stageProvider.CurrentStageResult.Value != StageResult.Uncompleted)
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
                .AddSystem(new DealDamageToFirstTargetsSystem(config.EnemiesCount, _lifeContext, upgrade.Percent.Value))
                .AddSystem(new EffectFinalizeSystem());
        }
        private void SetupFireballDamageMultiplierUpgrade(Entity upgrade, FireballDamageMultiplierConfig config)
        {
            upgrade
                .AddTowerHealOnWaveStartUpgradeTag()
                .AddIsEffectApplied()
                .AddMultiplier(new(config.Multiplier));

            upgrade
                .AddSystem(new DamageMultiplierApplySystem());
        }

        private void SetupTowerHealUpgrade(Entity upgrade, TowerHealConfig config)
        {
            upgrade
                .AddTowerHealOnWaveStartUpgradeTag()
                .AddIsEffectApplied()
                .AddPercent(new(config.HealPercent));

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
        }

        private Entity CreateCommon(Entity owner)
        {
            Entity upgrade = new();
            upgrade.Hierarchy.Value.SetParent(owner);
            return upgrade;
        }
    }
}