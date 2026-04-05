using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewFireballAbilityConfig", fileName = "FireballAbilityConfig")]
    public class FireballAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public float FlySpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public ExplosionAbilityConfig ExplosionConfig { get; private set; }
        [field: SerializeField] public float ProcessTime { get; private set; }
    }
}