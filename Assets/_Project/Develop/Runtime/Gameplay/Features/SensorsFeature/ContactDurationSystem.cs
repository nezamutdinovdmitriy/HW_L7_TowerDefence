using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class ContactDurationSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contactsEntities;
        private Dictionary<Entity, float> _entityTimers;

        private readonly List<Entity> _removeBuffer = new();

        public void OnInitialize(Entity entity)
        {
            _contactsEntities = entity.ContactsEntitiesBuffer;
            _entityTimers = entity.ContactsEntityTimers;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contactsEntities.Count; i++)
            {
                Entity target = _contactsEntities.Items[i];

                if (_entityTimers.ContainsKey(target) == false)
                    _entityTimers.Add(target, 0f);
            }

            for (int i = 0; i < _contactsEntities.Count; i++)
            {
                Entity target = _contactsEntities.Items[i];

                if (_entityTimers.ContainsKey(target))
                    _entityTimers[target] += deltaTime;
            }

            CleanupMissingEntities();
        }

        private void CleanupMissingEntities()
        {
            _removeBuffer.Clear();

            foreach (var key in _entityTimers.Keys)
                if (ContainsInContacts(key) == false)
                    _removeBuffer.Add(key);

            for (int i = 0; i < _removeBuffer.Count; i++)
                _entityTimers.Remove(_removeBuffer[i]);
        }

        private bool ContainsInContacts(Entity target)
        {
            for (int i = 0; i < _contactsEntities.Count; i++)
                if (_contactsEntities.Items[i] == target)
                    return true;

            return false;
        }
    }
}