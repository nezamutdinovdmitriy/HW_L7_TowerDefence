using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades
{
    [CreateAssetMenu(
        menuName = "Configs/Meta/Upgrades/NewUpgradesViewConfig",
        fileName = "UpgradesViewConfig")]
    public class UpgradesViewConfig : ScriptableObject
    {
        [SerializeField] private List<UpgradeViewData> _upgradesView;

        public UpgradeViewData GetConfigBy(UpgradeType type)
            => _upgradesView.First(upgrade => upgrade.Type == type);

        public IReadOnlyList<UpgradeViewData> Upgrades => _upgradesView;

        [Serializable]
        public class UpgradeViewData
        {
            [field: SerializeField] public UpgradeType Type { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
            [field: SerializeField] public string Description { get; private set; }
        }
    }
}