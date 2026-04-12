using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewFireballAbilityConfig", fileName = "FireballAbilityConfig")]
    public class FireballAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public string AbilityParameterKey { get; private set; }
        [field: SerializeField] public ProjectileConfig ProjectileConfig { get; private set; }
        [field: SerializeField] public ExplosionConfig ExplosionConfig { get; private set; }
    }
}