using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Common
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Common/NewExplosionConfig", fileName = "ExplosionConfig")]
    public class ExplosionConfig : ScriptableObject
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public float ExplosionDamage { get; private set; }
        [field: SerializeField] public float ExplosionRadius { get; private set; }
    }
}