using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class AreaContactDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _radius;
        private Buffer<Collider> _contactsColliders;
        private Transform _transform;
        private LayerMask _contactsMask;

        ICompositeCondition _canStartDetecting;

        public void OnInitialize(Entity entity)
        {
            _radius = entity.AreaContactDetectingRadius;
            _contactsColliders = entity.ContactsCollidersBuffer;
            _transform = entity.Transfrom;
            _contactsMask = entity.ContactsDetectingMask;

            _canStartDetecting = entity.CanStartDetecting;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canStartDetecting.Evaluate())
            {
                _contactsColliders.Count = GetContactsCount();
            }
        }

        private int GetContactsCount()
        {
            return Physics.OverlapSphereNonAlloc(
                _transform.position,
                _radius.Value,
                _contactsColliders.Items,
                _contactsMask,
                QueryTriggerInteraction.Ignore
                );
        }
    }
}