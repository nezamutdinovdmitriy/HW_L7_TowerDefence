using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public sealed class ArcaneMineStartSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly CombatEntityFactory _combatEntityFactory;

        private ReactiveEvent _useRequest;
       
        private Entity _ability;
        private ReactiveVariable<Vector3> _aimPoint;

        private ICompositeCondition _canUse;
        
        private IDisposable _disposable;

        public ArcaneMineStartSystem(CombatEntityFactory combatEntityFactory)
            => _combatEntityFactory = combatEntityFactory;

        public void OnInitialize(Entity entity)
        {
            _ability = entity;
            _useRequest = entity.AbilityUseRequest;
            _aimPoint = entity.AimPoint;
            _canUse = entity.CanUseArcaneMine;

            _disposable = _useRequest.Subscribe(OnAbilityUseRequested);
        }

        public void OnDispose() => _disposable.Dispose();

        private void OnAbilityUseRequested()
        {
            if (_canUse.Evaluate())
                _combatEntityFactory.CreateArcaneMine(_ability, _ability.AbilityArcaneMineConfig);
        }
    }
}