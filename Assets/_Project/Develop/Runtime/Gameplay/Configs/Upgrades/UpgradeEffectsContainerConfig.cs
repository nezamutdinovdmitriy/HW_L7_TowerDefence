using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades
{
    [CreateAssetMenu(
        menuName = "Configs/Gameplay/Upgrades/NewUpgradeEffectsContainerConfig",
        fileName = "UpgradeEffectsContainerConfig")]
    public class UpgradeEffectsContainerConfig : ScriptableObject
    {
        [SerializeField] private List<UpgradeEffectConfig> _containerEffects;

        public UpgradeEffectConfig GetConfigBy(UpgradeType upgradeType)
            => _containerEffects.Find(config => config.UpgradeType == upgradeType);
    }
}