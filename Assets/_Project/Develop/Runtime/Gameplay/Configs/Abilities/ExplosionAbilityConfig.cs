using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewExplosionAbilityConfig", fileName = "ExplosionAbilityConfig")]
    public class ExplosionAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public AbilityType AbilityType { get; private set; }
        [field: SerializeField] public AbilitySlotType AbilitySlot { get; private set; }
        [field: SerializeField] public string AbilityParameterKey { get; private set; }
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public float InitialTime { get; private set; }
        [field: SerializeField] public float EffectSpawnDelay { get; private set; }
        [field: SerializeField] public float ExplosionDamage { get; private set; }
        [field: SerializeField] public float ExplosionRadius { get; private set; }
    }
}