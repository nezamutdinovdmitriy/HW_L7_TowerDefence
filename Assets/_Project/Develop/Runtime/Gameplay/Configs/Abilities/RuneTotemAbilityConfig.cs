using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(
        menuName = "Configs/Gameplay/Abilities/NewRuneTotemAbilityConfig",
        fileName = "RuneTotemAbilityConfig")]
    public class RuneTotemAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public CurrencyType CostCurrency { get; private set; }
        [field: SerializeField] public int ActivationCost { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public ProjectileConfig ProjectileConfig { get; private set; }
        [field: SerializeField] public ExplosionConfig ExplosionConfig { get; private set; }
    }
}