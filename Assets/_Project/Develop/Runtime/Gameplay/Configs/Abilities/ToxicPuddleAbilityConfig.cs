using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(
        menuName = "Configs/Gameplay/Abilities/NewToxicPuddleAbilityConfig",
        fileName = "ToxicPuddleAbilityConfig")]
    public class ToxicPuddleAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public float DamagePerTick { get; private set; }
        [field: SerializeField] public float CooldownTick { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public CurrencyType CostCurrency { get; private set; }
        [field: SerializeField] public int ActivationCost { get; private set; }
    }
}