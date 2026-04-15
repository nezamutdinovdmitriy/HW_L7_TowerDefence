using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat
{
    public sealed class ExplosionState : State, IUpdatableState, IDisposable
    {
        private readonly Entity _entity;

        private ReactiveVariable<bool> _castInProcess;

        private IDisposable _disposable;

        public ExplosionState(Entity entity)
        {
            _entity = entity;

            _castInProcess = entity.AbilityCastInProcess;
        }

        public override void Enter()
        {
            base.Enter();

            _disposable = _castInProcess.Subscribe(OnCastProcessChanged);

            _entity.ShouldCastAbility.Value = true;
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("EXIT_DISPOSE");

            _disposable?.Dispose();
        }

        public void Dispose()
        {
            Debug.Log("DISPOSE");
            _disposable?.Dispose();
        }

        private void OnCastProcessChanged(bool arg1, bool value)
        {
            if(value == false)
                _entity.IsDead.Value = true;
        }

        public void Update(float deltaTime)
        {
            //if (_entity.AbilityCastInProcess.Value)
            //{
            //    _castStarted = true;
            //    _entity.ShouldCastAbility.Value = false;
            //}

            //if (_entity.AbilityCastInProcess.Value == false)
            //    _entity.IsDead.Value = true;
        }
    }
}