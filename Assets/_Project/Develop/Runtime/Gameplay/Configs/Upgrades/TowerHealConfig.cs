using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades
{
    [CreateAssetMenu(
        menuName = "Configs/Gameplay/Upgrades/NewTowerHealConfig", 
        fileName = "TowerHealConfig")]
    public class TowerHealConfig : UpgradeEffectConfig
    {
        [field: SerializeField, Min(0)] public int HealPercent { get; private set; }
    }
}