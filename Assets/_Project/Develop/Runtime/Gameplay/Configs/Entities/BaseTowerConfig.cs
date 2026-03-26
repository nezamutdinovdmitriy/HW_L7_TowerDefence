using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewBaseTowerConfig", fileName = "BaseTowerConfig")]
    public class BaseTowerConfig : EntityConfig
    {
        [field: SerializeField] public string PathToPrefab { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public int UtilityAbilityCost { get; private set; }
    }
}