using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using System;
using System.Collections.Generic;
using static Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades.UpgradesConfig;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradesService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly UpgradesConfig _upgradesConfig;
        private readonly HashSet<UpgradeType> _upgrades = new();

        public UpgradesService(UpgradesConfig upgradesConfig, PlayerDataProvider playerDataProvider)
        {
            _upgradesConfig = upgradesConfig;

            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

        public IReadOnlyCollection<UpgradeType> AvailableUpgrades => _upgrades;

        public CurrencyType GetUpgradeCostTypeBy(UpgradeType upgradeType)
            => _upgradesConfig.GetConfigBy(upgradeType).CostType;

        public float GetUpgradeCostBy(UpgradeType upgradeType)
            => _upgradesConfig.GetConfigBy(upgradeType).Cost;

        public bool TryGetUpgradeCost(UpgradeType upgradeType, out CurrencyType currency, out int cost)
        {
            UpgradeData upgradeData = _upgradesConfig.GetConfigBy(upgradeType);

            if (_upgrades.Contains(upgradeType))
            {
                currency = default;
                cost = default;
                return false;
            }

            currency = upgradeData.CostType;
            cost = upgradeData.Cost;
            return true;
        }

        public void ReadFrom(PlayerData data)
        {
            _upgrades.Clear();

            _upgrades.UnionWith(data.Upgrades);
        }

        public void WriteTo(PlayerData data)
        {
            data.Upgrades ??= new HashSet<UpgradeType>();

            data.Upgrades = new(_upgrades);
        }
    }
}