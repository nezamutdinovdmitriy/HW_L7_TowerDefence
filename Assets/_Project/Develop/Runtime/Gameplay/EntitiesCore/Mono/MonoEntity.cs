using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public sealed class MonoEntity : MonoBehaviour
    {
        private CollidersRegistryService _colllidersRegistryService;
        private Entity _linkedEntity;

        public Entity LinkedEntity => _linkedEntity;

        public void Initialize(CollidersRegistryService collidersRegistryService)
            => _colllidersRegistryService = collidersRegistryService;

        public void Link(Entity entity)
        {
            _linkedEntity = entity;

            MonoEntityRegistrator[] registrators = GetComponentsInChildren<MonoEntityRegistrator>();

            if (registrators != null)
                foreach (MonoEntityRegistrator registrator in registrators)
                    registrator.Register(entity);

            MonoEntityView[] views = GetComponentsInChildren<MonoEntityView>();

            if(views != null)
                foreach(MonoEntityView view in views)
                    view.Link(entity);

            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _colllidersRegistryService.Register(collider, entity);
        }

        public void Unlink(Entity entity)
        {
            MonoEntityView[] views = GetComponentsInChildren<MonoEntityView>();

            if (views != null)
                foreach (MonoEntityView view in views)
                    view.Link(entity);

            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _colllidersRegistryService?.Unregister(collider);

            _linkedEntity = null;
        }
    }
}