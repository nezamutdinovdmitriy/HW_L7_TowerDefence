using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public sealed class MouseRotationDirectionUpdateSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly ScreenToWorldPositionConverter _positionConverter;
        private readonly IGameplayInputService _input;

        private Transform _transform;
        private ICompositeCondition _canRotate;

        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<Vector3> _aimPoint;

        public MouseRotationDirectionUpdateSystem(
            ScreenToWorldPositionConverter positionConverter,
            IGameplayInputService input)
        {
            _positionConverter = positionConverter;
            _input = input;
        }

        public void OnInitialize(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            //_aimPoint = entity.AimPoint;
            _transform = entity.Transfrom;
            _canRotate = entity.CanRotate;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate())
            {
                if (_positionConverter.TryGetPosition(_input.Aiming.Value, out Vector3 worldPosition))
                {
                    _rotationDirection.Value = worldPosition - _transform.position;
                    _aimPoint.Value = worldPosition;
                }
            }
        }
    }
}