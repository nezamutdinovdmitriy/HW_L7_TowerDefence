using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class BodyContactDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _contactsMask;

        private CapsuleCollider _body;

        public void OnInitialize(Entity entity)
        {
            _body = entity.BodyCollider;

            _contacts = entity.ContactsCollidersBuffer;
            _contactsMask = entity.ContactsDetectingMask;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_body.gameObject.activeSelf == false)
                return;

            _contacts.Count = Physics.OverlapCapsuleNonAlloc(
                _body.bounds.min,
                _body.bounds.max,
                _body.radius,
                _contacts.Items,
                _contactsMask,
                QueryTriggerInteraction.Ignore
                );

            RemoveSelfFromContacts();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                    _contacts.Items[i] = _contacts.Items[i + 1];
                
                _contacts.Count--;
            }
        }
    }
}