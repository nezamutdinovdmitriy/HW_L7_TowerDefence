using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball
{
    public class FireballStartSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startedEvent;

        private AbilityEffectsFactory _combatEntityFactory;

        private Entity _ability;
        private Entity _owner;

        private IDisposable _disposable;

        public FireballStartSystem(AbilityEffectsFactory combatEntityFactory)
        {
            _combatEntityFactory = combatEntityFactory;
        }

        public void OnDispose()
        {
            _disposable?.Dispose();
        }

        public void OnInitialize(Entity entity)
        {
            _ability = entity;

            _owner = _ability.Hierarchy.Value.Parent;

            //_startedEvent = _ability.AbilityStartedEvent;

            //_disposable = _startedEvent.Subscribe(OnAbilityUseEvent);
        }

        private void OnAbilityUseEvent()
        {
            //Vector3 direction = (_owner.AimPoint.Value - _owner.ShootPoint.position).normalized;

            //_combatEntityFactory.CreateFireBall(_owner, _ability.AbilityFireballConfig);
        }
    }
}