using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public sealed class TransformMovementAppliedSystem : IInitializableSystem, IUpdatableSystem
    {
        private Transform _transform;
        private ReactiveVariable<Vector3> _movementDirection;

        public void OnInitialize(Entity entity)
        {
            _transform = entity.Transfrom;
            _movementDirection = entity.MovementDirection;
        }

        public void OnUpdate(float deltaTime) => _transform.position += _movementDirection.Value;
    }
}