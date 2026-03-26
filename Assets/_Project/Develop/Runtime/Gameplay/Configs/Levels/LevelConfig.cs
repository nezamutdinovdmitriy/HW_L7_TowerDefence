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
        [SerializeField] private int _victoryReward;
        [SerializeField] private float _preparationDuration;
        
        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;
        public float TowerMaxHealth => _towerMaxHealth;
        public int VictoryReward => _victoryReward;
        public Vector3 TowerSpawnPosition => _towerSpawnPosition;
        public float PreparationDuration => _preparationDuration;
    }
}