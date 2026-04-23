using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Data
{
    [Serializable]
    public class AbilityCastData
    {
        [field: SerializeField] public float InitialTime { get; private set; }
        [field: SerializeField] public float EffectSpawnDelay { get; private set; }
        [field: SerializeField] public float CastPerSecond { get; private set; }
    }
}