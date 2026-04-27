using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades
{
    [CreateAssetMenu(
        menuName = "Configs/Gameplay/Upgrades/NewDamageFirstTargetsConfig",
        fileName = "DamageFirstTargetsConfig")]
    public class DamageFirstTargetsConfig : UpgradeEffectConfig
    {
        [field: SerializeField, Min(0)] public int EnemiesCount { get; private set; }
        [field: SerializeField, Min(0)] public float DamagePercent { get; private set; }
    }
}