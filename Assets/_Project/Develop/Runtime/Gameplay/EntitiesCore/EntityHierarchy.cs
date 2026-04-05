using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntityHierarchy
    {
        private Entity _parent;
        private readonly List<Entity> _childrens = new();

        public Entity Parent => _parent;
        public IReadOnlyList<Entity> Children => _childrens;

        public EntityHierarchy SetParent(Entity entity)
        {
            _parent = entity;
            return this;
        }

        public EntityHierarchy AddChildren(Entity entity)
        {
            entity.Disposed += RemoveChildren;

            _childrens.Add(entity);
            return this;
        }

        public void RemoveChildren(Entity entity)
        {
            _childrens.Remove(entity);
            entity.Disposed -= RemoveChildren;
        }
    }
}