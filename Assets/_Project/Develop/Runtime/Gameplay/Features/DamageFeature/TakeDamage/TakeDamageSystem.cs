using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage
{
    public class TakeDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private Entity _entity;
        private Buffer<Entity> _contactsEntities;
        private ReactiveVariable<float> _damage;

        private HashSet<Entity> _processedEntities = new();
        private List<Entity> _removeBuffer = new();

        public void OnInitialize(Entity entity)
        {
            _entity = entity;
            _contactsEntities = entity.ContactsEntitiesBuffer;
            _damage = entity.ContactDamage;
        }

        public void OnUpdate(float deltaTime)
        {
            DealDamageOnNewContacts();
            CleanupProcessedEntities();
        }

        private void DealDamageOnNewContacts()
        {
            for (int i = 0; i < _contactsEntities.Count; i++)
            {
                Entity target = _contactsEntities.Items[i];
                if (_processedEntities.Add(target))
                {
                    EntitiesHelper.TryTakeDamageFrom(_entity, target, _damage.Value);
                    Debug.Log($"[TAKE DAMAGE SYSTEM] INVOKE TRY TAKE DAMAGE");
                }
                Debug.Log($"[TAKE DAMAGE SYSTEM] CONTACTS ENTITIES: {_contactsEntities.Count}");
            }
        }

        private void CleanupProcessedEntities()
        {
            _removeBuffer.Clear();

            foreach (Entity entity in _processedEntities)
                if (ContainInContacts(entity) == false)
                    _removeBuffer.Add(entity);

            for (int i = 0; i < _removeBuffer.Count; i++)
                _processedEntities.Remove(_removeBuffer[i]);
        }

        private bool ContainInContacts(Entity entity)
        {
            for (int i = 0; i < _contactsEntities.Count; i++)
                if (_contactsEntities.Items[i] == entity)
                    return true;

            return false;
        }
    }
}