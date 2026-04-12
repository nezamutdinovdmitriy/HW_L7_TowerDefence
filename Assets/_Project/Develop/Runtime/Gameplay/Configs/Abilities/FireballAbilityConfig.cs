using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewFireballAbilityConfig", fileName = "FireballAbilityConfig")]
    public class FireballAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public AbilityType AbilityType { get; private set; }
        [field: SerializeField] public AbilitySlotType AbilitySlot { get; private set; }
        [field: SerializeField] public string AbilityParameterKey { get; private set; }
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public float ProjectileSpeed { get; private set; }
        [field: SerializeField] public float ProjectileRotationSpeed { get; private set; }
        [field: SerializeField] public float InitialTime { get; private set; }
        [field: SerializeField] public float EffectSpawnDelay { get; private set; }
        [field: SerializeField] public ExplosionAbilityConfig ExplosionConfig { get; private set; }
    }
}