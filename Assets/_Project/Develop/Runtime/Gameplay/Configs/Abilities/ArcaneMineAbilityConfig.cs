using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewArcaneMineAbilityConfig", fileName = "ArcaneMineAbilityConfig")]
    public class ArcaneMineAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public AbilityType AbilityType { get; private set; }
        [field: SerializeField] public AbilitySlotType AbilitySlot { get; private set; }
        [field: SerializeField] public string AbilityParameterKey { get; private set; }
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public float InitialTime { get; private set; }
        [field: SerializeField] public float EffectSpawnDelay { get; private set; }
        [field: SerializeField] public ExplosionAbilityConfig ExplosionConfig { get; private set; }
        [field: SerializeField] public float ActivationRadius { get; private set; }
        [field: SerializeField] public int ActivationCost { get; private set; }
        [field: SerializeField] public CurrencyType CostCurrency { get; private set; }
    }
}