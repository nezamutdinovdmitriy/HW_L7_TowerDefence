using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly float _deathZone;

        private Transform _transform;
        private ReactiveVariable<float> _rotationSpeed;
        private ReactiveVariable<Vector3> _currentDirection;

        public TransformRotationSystem(Vector3 inputDirection, float deathZone)
        {

        }

        public void OnInitialize(Entity entity)
        {
            _transform = entity.Transfrom;
            _rotationSpeed = entity.RotationSpeed;
            _currentDirection = entity.MoveDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            
        }
    }
}