using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public sealed class MovementDirectionResolveSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _movementSpeed;
        private ReactiveVariable<bool> _isMoving;
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<Vector3> _inputMovementDirection;

        private ICompositeCondition _canMove;

        public void OnInitialize(Entity entity)
        {
            _movementSpeed = entity.MovementSpeed;
            _inputMovementDirection = entity.InputMovementDirection;
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

            _movementDirection.Value = _inputMovementDirection.Value.normalized * _movementSpeed.Value * deltaTime;
            _isMoving.Value = true;
        }
    }
}