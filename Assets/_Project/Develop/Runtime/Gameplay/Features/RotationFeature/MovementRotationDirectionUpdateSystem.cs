using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public sealed class MovementRotationDirectionUpdateSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<Vector3> _rotationDirection;

        public void OnInitialize(Entity entity)
        {
            _movementDirection = entity.MovementDirection;
            _rotationDirection = entity.RotationDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            _rotationDirection.Value = _movementDirection.Value;
        }
    }
}