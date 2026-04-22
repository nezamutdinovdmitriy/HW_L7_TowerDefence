using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using System.Collections.Generic;
using static Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades.UpgradesConfig;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradesService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly ConfigsProvider _configProvider;
        private readonly HashSet<UpgradeType> _upgrades = new();

        public UpgradesService(ConfigsProvider configProvider, PlayerDataProvider playerDataProvider)
        {
            _configProvider = configProvider;

            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

        public UpgradesConfig PlayerUpgradesConfig => _configProvider.GetConfig<UpgradesConfig>();

        public IReadOnlyCollection<UpgradeType> AvailableUpgrades => _upgrades;

        public CurrencyType GetUpgradeCostTypeBy(UpgradeType upgradeType)
            => PlayerUpgradesConfig.GetConfigBy(upgradeType).CostType;

        public float GetUpgradeCostBy(UpgradeType upgradeType)
            => PlayerUpgradesConfig.GetConfigBy(upgradeType).Cost;

        public bool TryGetUpgradeCost(UpgradeType upgradeType, out CurrencyType currency, out int cost)
        {
            UpgradeData upgradeData = PlayerUpgradesConfig.GetConfigBy(upgradeType);

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

        public void AddUpgrade(UpgradeType upgradeType) => _upgrades.Add(upgradeType);

        public void ReadFrom(PlayerData data) => _upgrades.UnionWith(data.Upgrades);

        public void WriteTo(PlayerData data) => data.Upgrades.UnionWith(_upgrades);
    }
}