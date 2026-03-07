using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class MouseRotationDirectionProvider : IRotationDirectionProvider
    {
        private readonly ScreenToWorldPositionConverter _positionConverter;
        private readonly Transform _transform;
        private readonly IGameplayInputService _input;

        public MouseRotationDirectionProvider(
            ScreenToWorldPositionConverter positionConverter,
            Transform transform,
            IGameplayInputService input
            )
        {
            _positionConverter = positionConverter;
            _transform = transform;
            _input = input;
        }

        public Vector3 GetRotationDirection()
        {
            Vector3 worldPosition = _positionConverter.GetPosition(_input.Aiming.Value, _transform.position.y);

            Vector3 direction = worldPosition - _transform.position;

            return direction;
        }
    }
}