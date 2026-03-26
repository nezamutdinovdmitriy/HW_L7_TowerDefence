using Assets._Project.Develop.Runtime.Gameplay.Configs.Stages;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<StageConfig> _stageConfigs;
        [SerializeField] private float _towerMaxHealth;
        [SerializeField] private Vector3 _towerSpawnPosition;
        
        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;
        public float TowerMaxHealth => _towerMaxHealth;
        public Vector3 TowerSpawnPosition => _towerSpawnPosition;
    }
}