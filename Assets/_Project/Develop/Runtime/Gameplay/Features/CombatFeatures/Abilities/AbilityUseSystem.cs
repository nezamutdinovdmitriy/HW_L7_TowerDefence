using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public sealed class AbilityUseSystem : IInitializableSystem, IUpdatableSystem
    {
        private Dictionary<AbilityType, Entity> _abilityStorage;
        private ReactiveVariable<AbilityType> _abilityCurrent;

        private ICompositeCondition _canUse;

        public void OnInitialize(Entity entity)
        {
            _abilityStorage = entity.AbilityStorage;
            _abilityCurrent = entity.AbilityCurrent;
            _canUse = entity.AbilityCanUse;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canUse.Evaluate())
            {
                _abilityStorage[_abilityCurrent.Value].AbilityUseRequest.Invoke();
                Debug.Log("ABILITY INVOKED!");
            }
        }
    }
}