using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RotationDirectionUpdateSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private IRotationDirectionProvider _rotationDirectionProvider;

        public RotationDirectionUpdateSystem(IRotationDirectionProvider rotationDirectionProvider)
            => _rotationDirectionProvider = rotationDirectionProvider;

        public void OnInitialize(Entity entity)
        {
            Debug.Log("+");
            _rotationDirection = entity.RotationDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.Log("+++");
            Vector3 direction = _rotationDirectionProvider.GetRotationDirection();

            _rotationDirection.Value = direction;
        }

        public void SetProvider(IRotationDirectionProvider provider) => _rotationDirectionProvider = provider;
    }
}