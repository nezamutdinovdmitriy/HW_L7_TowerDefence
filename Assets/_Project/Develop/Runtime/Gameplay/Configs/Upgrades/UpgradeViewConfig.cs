using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(
    menuName = "Configs/Meta/Upgrades/NewUpgradesViewConfig",
    fileName = "UpgradesViewConfig")]
public class UpgradesViewConfig : ScriptableObject
{
    [SerializeField] private List<UpgradeViewData> _upgradesView;

    public UpgradeViewData GetConfigBy(UpgradeType type)
        => _upgradesView.First(upgrade => upgrade.Type == type);

    [Serializable]
    public class UpgradeViewData
    {
        [field: SerializeField] public UpgradeType Type { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
