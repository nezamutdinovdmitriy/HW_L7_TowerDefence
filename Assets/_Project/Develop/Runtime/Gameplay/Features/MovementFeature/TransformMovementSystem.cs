using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public sealed class TransformMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private Transform _transform;

        private ReactiveVariable<float> _movementSpeed;
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<bool> _isMoving;

        private ICompositeCondition _canMove;

        private IGameplayInputService _input;

        public TransformMovementSystem(IGameplayInputService input)
        {
            _input = input;
        }

        public void OnInitialize(Entity entity)
        {
            _transform = entity.Transfrom;
            _movementSpeed = entity.MovementSpeed;
            _movementDirection = entity.MovementDirection;
            _canMove = entity.CanMove;
            _isMoving = entity.IsMoving;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canMove.Evaluate() == false)
            {
                _isMoving.Value = false;
                return;
            }

            _movementDirection.Value = _input.MovementDirection.normalized * _movementSpeed.Value * deltaTime;

            _transform.position += _movementDirection.Value;

            _isMoving.Value = true;
        }
    }
}