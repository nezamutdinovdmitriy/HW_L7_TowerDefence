using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades
{
    [CreateAssetMenu(
        menuName = "Configs/Gameplay/Upgrades/NewFireballDamageMultiplierConfig",
        fileName = "FireballDamageMultiplierConfig")]
    public class FireballDamageMultiplierConfig : UpgradeEffectConfig
    {
        [field: SerializeField, Min(0)] public float Multiplier { get; private set; }
    }
}