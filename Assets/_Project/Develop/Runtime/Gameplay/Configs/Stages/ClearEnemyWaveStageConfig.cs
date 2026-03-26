using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Stages
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Stages/NewClearEnemyWaveStageConfig", fileName = "ClearEnemyWaveStageConfig")]
    public class ClearEnemyWaveStageConfig : StageConfig
    {
        [SerializeField] private List<EnemyWaveConfig> _waveConfigs;
        public IReadOnlyList<EnemyWaveConfig> WaveConfigs => _waveConfigs;
    }
}