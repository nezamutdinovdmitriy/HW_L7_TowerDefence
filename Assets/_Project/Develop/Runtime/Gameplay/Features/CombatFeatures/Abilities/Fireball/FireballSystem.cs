using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball
{
    public class FireballSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly CombatEntityFactory _combatEntityFactory;

        private ReactiveEvent _useRequest;

        private Entity _entity;
        private ReactiveVariable<Vector3> _aimPoint;

        private ICompositeCondition _canUse;

        private IDisposable _disposable;

        public FireballSystem(CombatEntityFactory combatEntityFactory)
            => _combatEntityFactory = combatEntityFactory;

        public void OnInitialize(Entity entity)
        {
            _useRequest = entity.FireballUseRequest;
            
            _entity = entity;
            _aimPoint = entity.AimPoint;

            _canUse = entity.CanUseFireball;

            _disposable = _useRequest.Subscribe(OnAbilityUseRequested);
        }

        public void OnDispose() => _disposable.Dispose();

        private void OnAbilityUseRequested()
        {
            if (_canUse.Evaluate())
            {
                Vector3 direction = (_aimPoint.Value - _entity.ShootPoint.position).normalized;

                _combatEntityFactory.CreateFireBall(_entity.ShootPoint.position, direction, _entity);
            }
        }
    }
}