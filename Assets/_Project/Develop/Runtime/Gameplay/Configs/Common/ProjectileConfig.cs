using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Common
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Common/NewProjectileConfig", fileName = "ProjectileConfig")]
    public class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public float ProjectileSpeed { get; private set; }
        [field: SerializeField] public float ProjectileRotationSpeed { get; private set; }
    }
}