using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Casts;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewBaseCreepConfig", fileName = "BaseCreepConfig")]
    public sealed class BaseCreepConfig : EntityConfig
    {
        [field: SerializeField] public string PathToPrefab { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }

        [field: SerializeField] private List<AbilityData> _abilities = new();

        [field: SerializeField] public TeamType Team { get; private set; }

        public Dictionary<AbilitySlotType, AbilityConfig> GetAbilities()
        {
            Dictionary<AbilitySlotType, AbilityConfig> abilities = new();

            foreach (AbilityData abilityData in _abilities)
                abilities.Add(abilityData.AbilityType, abilityData.Config);

            return abilities;
        }

        public bool TryGetAbilityConfigFor(AbilitySlotType abilityType, out AbilityConfig abilityConfig)
        {
            AbilityData abilityData = _abilities.FirstOrDefault(data => data.AbilityType == abilityType);

            if (abilityData == null)
            {
                abilityConfig = default;
                return false;
            }

            abilityConfig = abilityData.Config;
            return true;
        }

        [Serializable]
        private class AbilityData
        {
            public AbilitySlotType AbilityType;
            public AbilityConfig Config;
        }
    }
}