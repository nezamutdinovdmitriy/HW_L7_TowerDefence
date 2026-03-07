using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RotationDirectionUpdateSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private RotationDirectionProvidersHolder _rotationDirectionProviderService;
        
        public RotationDirectionUpdateSystem(RotationDirectionProvidersHolder rotationDirectionProviderService)
            => _rotationDirectionProviderService = rotationDirectionProviderService;

        public void OnInitialize(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 direction = _rotationDirectionProviderService.CurrentProvider.GetRotationDirection();

            _rotationDirection.Value = direction;
        }
    }
}