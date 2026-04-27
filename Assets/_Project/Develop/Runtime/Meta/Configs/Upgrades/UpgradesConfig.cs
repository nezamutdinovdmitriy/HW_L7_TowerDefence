using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Configs.Upgrades
{
    [CreateAssetMenu(
    menuName = "Configs/Meta/Upgrades/NewUpgradesConfig",
    fileName = "UpgradesConfig")]
    public class UpgradesConfig : ScriptableObject
    {
        [SerializeField] private List<UpgradeData> _upgrades;

        public UpgradeData GetConfigBy(UpgradeType type)
            => _upgrades.First(upgrade => upgrade.Type == type);

        [Serializable]
        public class UpgradeData
        {
            [field: SerializeField] public UpgradeType Type { get; private set; }
            [field: SerializeField] public CurrencyType CostType { get; private set; }
            [field: SerializeField] public int Cost { get; private set; }
        }
    }
}