using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public sealed class AbilityUseSystem : IInitializableSystem, IUpdatableSystem
    {
        private Dictionary<AbilitySlotType, Entity> _abilityStorage;
        private ReactiveVariable<AbilitySlotType> _abilityCurrent;

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
                _abilityStorage[_abilityCurrent.Value].AbilityUseRequest.Invoke();
        }
    }
}