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

        private CapsuleCollider _ownerCollider;

        ICompositeCondition _canStartDetecting;

        public AreaContactDetectingSystem(CapsuleCollider ownerCollider)
        {
            _ownerCollider = ownerCollider;
        }

        public void OnInitialize(Entity entity)
        {
            _radius = entity.ExplosionRadius;
            _contactsColliders = entity.ContactsCollidersBuffer;
            _transform = entity.Transfrom;
            _contactsMask = entity.ContactsDetectingMask;

            _canStartDetecting = entity.CanStartDetecting;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canStartDetecting.Evaluate())
            {
                _contactsColliders.Count = Physics.OverlapSphereNonAlloc(
                    _transform.position,
                    _radius.Value,
                    _contactsColliders.Items,
                    _contactsMask,
                    QueryTriggerInteraction.Ignore);
            }

            RemoveSelfFromContacts();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contactsColliders.Count; i++)
            {
                if (_contactsColliders.Items[i] == _ownerCollider)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contactsColliders.Count - 1; i++)
                    _contactsColliders.Items[i] = _contactsColliders.Items[i + 1];

                _contactsColliders.Count--;
            }
        }
    }
}