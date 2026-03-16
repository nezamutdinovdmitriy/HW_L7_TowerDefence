using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class SelfContactFilterSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contactsColliders;
        private Collider _selfColldier;

        public void OnInitialize(Entity entity)
        {
            _contactsColliders = entity.ContactsCollidersBuffer;
            _selfColldier = entity.BodyCollider;
        }

        public void OnUpdate(float deltaTime) => RemoveSelfFromContacts();

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contactsColliders.Count; i++)
            {
                if (_contactsColliders.Items[i] == _selfColldier)
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