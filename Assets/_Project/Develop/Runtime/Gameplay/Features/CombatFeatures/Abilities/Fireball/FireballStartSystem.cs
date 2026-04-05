using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball
{
    public class FireballStartSystem : IInitializableSystem
    {
        private ReactiveEvent _useRequest;
        private ReactiveEvent _startedEvent;

        private Entity _owner;

        private Entity _ability;

        private ICompositeCondition _canUse;
        private IDisposable _disposable;

        public void OnInitialize(Entity entity)
        {
            _owner = entity;

            _ability = entity.AbilityStorage[entity.AbilityCurrent.Value];

            _useRequest = _ability.AbilityUseRequest;
            _startedEvent = _ability.AbilityStartedEvent;

            _disposable = _useRequest.Subscribe(OnAbilityUseRequested);
        }

        private void OnAbilityUseRequested()
        {
            if(_canUse.Evaluate())
                _startedEvent?.Invoke();

        }
    }
}