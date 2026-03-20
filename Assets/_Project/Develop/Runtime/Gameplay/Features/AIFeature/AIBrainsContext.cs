using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature
{
    public sealed class AIBrainsContext : IDisposable
    {

        private readonly List<EntityToBrain> _entityToBrains = new();
        public void Dispose()
        {
            foreach (EntityToBrain link in _entityToBrains)
                link.Brain.Dispose();

            _entityToBrains.Clear();
        }

        public void SetFor(Entity entity, IBrain brain)
        {
            foreach (EntityToBrain link in _entityToBrains)
            {
                if (link.Entity == entity)
                {
                    link.Brain.Disable();
                    link.Brain.Dispose();
                    link.Brain = brain;
                    link.Brain.Enable();
                    return;
                }
            }

            _entityToBrains.Add(new EntityToBrain(entity, brain));
            brain.Enable();
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < _entityToBrains.Count; i++)
            {
                if (_entityToBrains[i].Entity.IsInit == false)
                {
                    int lastIndex = _entityToBrains.Count - 1;

                    _entityToBrains[i].Brain.Dispose();
                    _entityToBrains[i] = _entityToBrains[lastIndex];
                    _entityToBrains.RemoveAt(lastIndex);

                    i--;

                    continue;
                }

                _entityToBrains[i].Brain.Update(deltaTime);
            }
        }

        private sealed class EntityToBrain
        {
            public Entity Entity;
            public IBrain Brain;

            public EntityToBrain(Entity entity, IBrain brain)
            {
                Entity = entity;
                Brain = brain;
            }
        }
    }
}