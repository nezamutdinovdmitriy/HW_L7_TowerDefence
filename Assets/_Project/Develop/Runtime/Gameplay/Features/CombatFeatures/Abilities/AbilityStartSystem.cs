using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public class AbilityStartSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _useRequest;
        private ReactiveEvent _startedEvent;

        private IDisposable _disposable;

        public void OnInitialize(Entity entity)
        {
            _useRequest = entity.AbilityUseRequest;
            _startedEvent = entity.AbilityStartedEvent;

            _disposable = _useRequest.Subscribe(OnAbilityUseRequested);
        }

        public void OnDispose()
        {
            _disposable.Dispose();
        }

        private void OnAbilityUseRequested()
        {
            _startedEvent?.Invoke();
        }
    }
}