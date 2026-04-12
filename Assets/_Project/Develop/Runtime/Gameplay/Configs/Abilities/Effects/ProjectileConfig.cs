using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Effects
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/Effects/NewProjectileConfig", fileName = "ProjectileConfig")]
    public class ProjectileConfig : AbilityEffectConfig
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
    }
}