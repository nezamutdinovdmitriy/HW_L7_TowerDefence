using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Data
{
    [Serializable]
    public class AbilityData
    {
        [field: SerializeField] public AbilityType AbilityType { get; private set; }
        [field: SerializeField] public AbilitySlotType AbilitySlot { get; private set; }
    }
}