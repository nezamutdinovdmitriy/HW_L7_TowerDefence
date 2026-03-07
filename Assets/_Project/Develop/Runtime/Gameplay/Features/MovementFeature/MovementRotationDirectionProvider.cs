using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class MovementRotationDirectionProvider : IRotationDirectionProvider
    {
        private readonly ReactiveVariable<Vector3> _movementDirection;

        public MovementRotationDirectionProvider(ReactiveVariable<Vector3> movementDirection)
            => _movementDirection = movementDirection;


        public Vector3 GetRotationDirection() => _movementDirection.Value;
    }
}