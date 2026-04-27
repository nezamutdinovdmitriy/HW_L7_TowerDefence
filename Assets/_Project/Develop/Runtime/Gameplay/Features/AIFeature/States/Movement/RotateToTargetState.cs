using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Movement
{
    public class RotateToTargetState : State, IUpdatableState
    {
        private readonly ReactiveVariable<Vector3> _rotationDirection;
        private readonly ReactiveVariable<Entity> _currentTarget;
        private readonly Transform _transform;

        private readonly Entity _entity;

        public RotateToTargetState(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transfrom;
            _entity = entity;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value != null)
            {
                _entity.InputAimPoint.Value = _entity.CurrentTarget.Value.Transfrom.position;
                _rotationDirection.Value = (_currentTarget.Value.Transfrom.position - _transform.position).normalized;
            }
        }
    }
}