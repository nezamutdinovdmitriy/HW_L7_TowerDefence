using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public sealed class MonoEntitiesLifeContext : IDisposable
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly Dictionary<Entity, MonoEntity> _entityToMonoEntity = new();

        public MonoEntitiesLifeContext(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
            _entitiesLifeContext.Removed += Remove;
        }

        public void Add(Entity entity, MonoEntity monoEntity)
            => _entityToMonoEntity.Add(entity, monoEntity);

        public void Dispose()
        {
            _entitiesLifeContext.Removed -= Remove;

            foreach (Entity entity in _entityToMonoEntity.Keys)
                UnlinkFor(entity);

            _entityToMonoEntity.Clear();
        }

        private void Remove(Entity entity)
        {
            UnlinkFor(entity);

            _entityToMonoEntity.Remove(entity);
        }

        private void UnlinkFor(Entity entity)
        {
            MonoEntity monoEntity = _entityToMonoEntity[entity];
            monoEntity.Unlink(entity);

            Object.Destroy(monoEntity.gameObject);
        }
    }
}