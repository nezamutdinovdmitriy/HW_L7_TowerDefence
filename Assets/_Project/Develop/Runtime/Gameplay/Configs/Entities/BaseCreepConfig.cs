using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewBaseCreepConfig", fileName = "BaseCreepConfig")]
    public sealed class BaseCreepConfig : EntityConfig
    {
        [field: SerializeField] public string PathToPrefab { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public ExplosionAbilityConfig ExplosionAbilityConfig { get; private set; }
        [field: SerializeField] public TeamType Team { get; private set; }
    }
}