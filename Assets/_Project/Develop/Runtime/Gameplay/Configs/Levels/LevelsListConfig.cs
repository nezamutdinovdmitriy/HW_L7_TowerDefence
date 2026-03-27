using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelsListConfig", fileName = "LevelsListConfig")]
    public sealed class LevelsListConfig : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levels;

        public IReadOnlyList<LevelConfig> Levels => _levels;

        public LevelConfig GetConfigBy(int levelNumber)
        {
            int levelIndex = levelNumber - 1;
            return _levels[levelIndex];
        }
    }
}