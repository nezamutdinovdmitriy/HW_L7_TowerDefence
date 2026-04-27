using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature
{
    public class UpgradesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _lifeContext;
        private readonly UpgradeEffectsContainerConfig _configs;

        public UpgradesFactory(
            DIContainer container,
            EntitiesLifeContext lifeContext)
        {
            _container = container;
            _lifeContext = lifeContext;
            _configs = _container.Resolve<ConfigsProvider>().GetConfig<UpgradeEffectsContainerConfig>();
        }

        public Entity Create(Entity owner, UpgradeType upgradeType)
        {
            Entity upgrade = CreateCommon(owner);
            var config = _configs.GetConfigBy(upgradeType);

            switch (config)
            {
                case TowerHealConfig towerHealConfig:
                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();

                    break;

                case FireballDamageMultiplierConfig towerHealConfig:
                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();

                    break;

                case DamageFirstTargetsConfig towerHealConfig:
                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();

                    break;

                default:
                    throw new Exception($"Unsupported upgrade type {upgradeType}");
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