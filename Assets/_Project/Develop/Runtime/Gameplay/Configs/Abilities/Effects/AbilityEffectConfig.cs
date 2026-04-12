using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Effects
{
    public class AbilityEffectConfig : ScriptableObject
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
    }
}