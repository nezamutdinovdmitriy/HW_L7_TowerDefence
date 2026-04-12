using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Data;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public AbilityData AbilityData { get; private set; }
        [field: SerializeField] public AbilityCastData CastData { get; private set; }
    }
}