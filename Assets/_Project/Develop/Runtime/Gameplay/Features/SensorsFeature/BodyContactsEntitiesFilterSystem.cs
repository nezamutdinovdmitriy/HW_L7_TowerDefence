using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class BodyContactsEntitiesFilterSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly CollidersRegistryService _collidersRegistryService;

        private Buffer<Collider> _contactsColliders;
        private Buffer<Entity> _contactsEntities;

        public BodyContactsEntitiesFilterSystem(CollidersRegistryService collidersRegistryService)
            => _collidersRegistryService = collidersRegistryService;

        public void OnInitialize(Entity entity)
        {
            _contactsColliders = entity.ContactsCollidersBuffer;
            _contactsEntities = entity.ContactsEntitiesBuffer;
        }

        public void OnUpdate(float deltaTime)
        {
            _contactsEntities.Count = 0;

            for (int i = 0; i < _contactsColliders.Count; i++)
            {
                Collider collider = _contactsColliders.Items[i];
                Entity contactEntity = _collidersRegistryService.GetBy(collider);

                if(contactEntity != null)
                {
                    _contactsEntities.Items[_contactsEntities.Count] = contactEntity;
                    _contactsEntities.Count++;

                    Debug.Log($"[BodyContactsEntitiesFilterSystem] CONTACTS ENTITIES: {_contactsEntities.Count}");
                }
            }
        }
    }
}