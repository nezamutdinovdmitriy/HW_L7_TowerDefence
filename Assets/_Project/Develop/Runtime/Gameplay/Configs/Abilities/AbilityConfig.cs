using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
    }
}