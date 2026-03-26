using Assets._Project.Develop.Runtime.Gameplay.Configs.Entities;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Stages
{
    [Serializable]
    public class EnemyWaveConfig
    {
        [field: SerializeField] public EntityConfig EntityConfig { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
    }
}