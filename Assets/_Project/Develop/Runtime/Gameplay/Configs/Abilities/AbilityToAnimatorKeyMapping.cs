using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/Mapping/NewAbilityToAnimatorKeyMapping", fileName = "AbilityToAnimatorKeyMapping")]
    public class AbilityToAnimatorKeyMapping : ScriptableObject
    {
        private readonly Dictionary<AbilityType, string> _abilityToKeys = new();

        [SerializeField] private List<AbilityAnimatorPair> _abilityAnimatorPairs;

        private void OnEnable() => InitializeAbilityDictionary();

        public bool TryGetCastProcessKey(AbilityType abilityType, out string animatorKey)
            => _abilityToKeys.TryGetValue(abilityType, out animatorKey);

        private void InitializeAbilityDictionary()
        {
            foreach (var pair in _abilityAnimatorPairs)
                if (_abilityToKeys.ContainsKey(pair.AbilityType) == false)
                    _abilityToKeys.Add(pair.AbilityType, pair.ProcessCastKey);
        }

        [Serializable]
        private class AbilityAnimatorPair
        {
            public AbilityType AbilityType;
            public string ProcessCastKey;
        }
    }
}