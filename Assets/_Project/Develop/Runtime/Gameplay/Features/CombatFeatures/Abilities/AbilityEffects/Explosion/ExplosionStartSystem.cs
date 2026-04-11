using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public sealed class ExplosionStartSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _startedEvent;

        private readonly AbilityEffectsFactory _combatEntityFactory;

        private Entity _ability;
        private Entity _owner;

        private ExplosionAbilityConfig _config;

        private Transform _transform;

        private ICompositeCondition _canUse;

        public ExplosionStartSystem(AbilityEffectsFactory combatEntityFactory, ExplosionAbilityConfig config)
        {
            _combatEntityFactory = combatEntityFactory;
            _config = config;
        }

        public void OnInitialize(Entity entity)
        {
            _ability = entity;

            _owner = entity.Hierarchy.Value.Parent;

            _transform = entity.Transfrom;

            _canUse = entity.CanSpawnExplosion;

            //_startedEvent = _ability.AbilityStartedEvent;

            //_disposable = _startedEvent.Subscribe(OnAbilityUseEvent);
        }

        //public void OnDispose()
        //{
        //    _disposable?.Dispose();
        //}

        //private void OnAbilityUseEvent()
        //{
        //    _combatEntityFactory.CreateExplosion(_transform.position, _ability, _config);
        //}

        public void OnUpdate(float deltaTime)
        {
            if (_canUse.Evaluate())
                _combatEntityFactory.CreateExplosion(_transform.position, _ability, _config);
        }
    }
}