using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewExplosionAbilityConfig", fileName = "ExplosionAbilityConfig")]
    public class ExplosionAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public string EffectPrefabPath { get; private set; }
        [field: SerializeField] public float ExplosionRadius { get; private set; }
        [field: SerializeField] public float ExplosionDamage { get; private set; }
        [field: SerializeField] public float ProcessTime { get; private set; }
    }
}