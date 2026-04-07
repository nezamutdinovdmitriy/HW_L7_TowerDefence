using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewArcaneMineAbilityConfig", fileName = "ArcaneMineAbilityConfig")]
    public class ArcaneMineAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public string MinePrefabPath { get; private set; }
        [field: SerializeField] public float ActivationRadius { get; private set; }
        [field: SerializeField] public CurrencyType CostCurrency { get; private set; }
        [field: SerializeField] public int ActivationCost { get; private set; }
        [field: SerializeField] public ExplosionAbilityConfig ExplosionConfig { get; private set; }
        [field: SerializeField] public float ProcessTime { get; private set; }
    }
}