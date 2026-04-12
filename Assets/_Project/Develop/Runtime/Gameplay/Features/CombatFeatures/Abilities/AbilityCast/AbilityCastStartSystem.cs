using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast
{
    public class AbilityCastStartSystem : IInitializableSystem, IUpdatableSystem
    {
        private Dictionary<AbilitySlotType, Entity> _abilityStorage;
        private ReactiveVariable<AbilitySlotType> _abilityCurrent;

        private ReactiveVariable<bool> _abilityCastInProcess;

        private ICompositeCondition _canCastAbility;

        public void OnInitialize(Entity entity)
        {
            _abilityStorage = entity.AbilityStorage;
            _abilityCurrent = entity.AbilityCurrent;

            _canCastAbility = entity.CanCastAbility;
            _abilityCastInProcess = entity.AbilityCastInProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_abilityCastInProcess.Value)
                return;

            if (_canCastAbility.Evaluate() == false)
                return;

            _abilityCastInProcess.Value = true;

            _abilityStorage[_abilityCurrent.Value].ShouldStartProcess.Value = true;

            Debug.Log("+++");
        }
    }
}