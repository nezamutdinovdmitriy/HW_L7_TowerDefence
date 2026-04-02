using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public sealed class TransformRotationAppliedSystem : IInitializableSystem, IUpdatableSystem
    {
        private const float DeathZone = 0.05f;
        private readonly float _maxVerticalAngle = 10f;

        private Transform _transform;

        private ReactiveVariable<float> _rotationSpeed;
        private ReactiveVariable<Vector3> _rotationDirection;

        public TransformRotationAppliedSystem(float maxVerticalAngle)
        {
            _maxVerticalAngle = maxVerticalAngle;
        }

        public void OnInitialize(Entity entity)
        {
            _transform = entity.Transfrom;
            _rotationSpeed = entity.RotationSpeed;
            _rotationDirection = entity.RotationDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_rotationDirection.Value.sqrMagnitude <= DeathZone * DeathZone)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_rotationDirection.Value.normalized);

            Vector3 euler = lookRotation.eulerAngles;
            if (euler.x > 180)
                euler.x -= 360;

            euler.x = Mathf.Clamp(euler.x, -_maxVerticalAngle, _maxVerticalAngle);

            lookRotation = Quaternion.Euler(euler);

            float step = _rotationSpeed.Value * deltaTime;

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }
    }
}