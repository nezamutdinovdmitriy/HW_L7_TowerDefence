using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewExplosionAbilityConfig", fileName = "ExplosionAbilityConfig")]
    public class ExplosionAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public ExplosionConfig ExplosionConfig { get; private set; }
    }
}