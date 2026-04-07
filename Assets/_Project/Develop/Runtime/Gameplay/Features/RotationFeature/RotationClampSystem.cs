using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RotationClampSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly float _maxVerticalAngle;

        private ReactiveVariable<Quaternion> _targetRotation;

        public RotationClampSystem(float maxVerticalAngle) => _maxVerticalAngle = maxVerticalAngle;

        public void OnInitialize(Entity entity) => _targetRotation = entity.TargetRotation;

        public void OnUpdate(float deltaTime)
        {
            Vector3 euler = _targetRotation.Value.eulerAngles;

            if (euler.x > 180)
                euler.x -= 360;

            euler.x = Mathf.Clamp(euler.x, -_maxVerticalAngle, _maxVerticalAngle);

            _targetRotation.Value = Quaternion.Euler(euler);
        }
    }
}