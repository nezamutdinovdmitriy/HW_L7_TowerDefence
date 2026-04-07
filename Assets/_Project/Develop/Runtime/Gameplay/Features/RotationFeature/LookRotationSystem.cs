using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class LookRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private const float DeathZone = 0.05f;

        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<Quaternion> _targetRotation;

        public void OnInitialize(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _targetRotation = entity.TargetRotation;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_rotationDirection.Value.sqrMagnitude <= DeathZone * DeathZone)
                return;

            _targetRotation.Value = Quaternion.LookRotation(_rotationDirection.Value.normalized);
        }
    }
}