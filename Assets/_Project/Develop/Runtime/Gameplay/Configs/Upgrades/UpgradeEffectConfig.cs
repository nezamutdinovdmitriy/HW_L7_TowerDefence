using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades
{
    public class UpgradeEffectConfig : ScriptableObject
    {
        [field: SerializeField] public UpgradeType UpgradeType { get; private set; }
    }
}