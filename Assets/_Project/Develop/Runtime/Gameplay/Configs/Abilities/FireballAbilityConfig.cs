using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewFireballAbilityConfig", fileName = "FireballAbilityConfig")]
    public class FireballAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public string ProjectilePrefabPath { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public ExplosionAbilityConfig ExplosionConfig { get; private set; }
        [field: SerializeField] public float ProcessTime { get; private set; }
    }
}