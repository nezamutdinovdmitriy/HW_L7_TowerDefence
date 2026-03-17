using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public class ArcaneMineSystem : IInitializableSystem, IDisposableSystem
    {
        private Entity _entity;
        private ICompositeCondition _canUse;
        private ReactiveEvent _useRequest;

        private IDisposable _disposable;

        private CombatEntityFactory _combatEntityFactory;

        private ReactiveVariable<Vector3> _aimPoint;

        public ArcaneMineSystem(CombatEntityFactory combatEntityFactory)
            => _combatEntityFactory = combatEntityFactory;

        public void OnInitialize(Entity entity)
        {
            _entity = entity;
            _canUse = entity.CanUseArcaneMine;
            _useRequest = entity.ArcaneMineUseRequest;

            _aimPoint = entity.AimPoint;

            _disposable = _useRequest.Subscribe(Use);
        }

        public void OnDispose() => _disposable.Dispose();

        private void Use()
        {
            if (_canUse.Evaluate())
                _combatEntityFactory.CreateArcaneMine(_aimPoint.Value, 3, 5, _entity);
        }
    }
}