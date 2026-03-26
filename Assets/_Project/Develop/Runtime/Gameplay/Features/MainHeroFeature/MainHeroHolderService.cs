using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature
{
    public sealed class MainHeroHolderService : IInitializable, IDisposable
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly ReactiveEvent<Entity> _heroRegistered = new();
        private readonly ReactiveEvent<Entity> _heroRemoved = new();
        private Entity _mainHero;

        public MainHeroHolderService(EntitiesLifeContext entitiesLifeContext)
            => _entitiesLifeContext = entitiesLifeContext;

        public IReadOnlyEvent<Entity> HeroRegistered => _heroRegistered;
        public Entity MainHero => _mainHero;

        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
            _entitiesLifeContext.Removed += OnEntityRemoved;
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
            _entitiesLifeContext.Removed -= OnEntityRemoved;
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<IsMainHero>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;

                _mainHero = entity;

                _heroRegistered?.Invoke(entity);
            }
        }

        private void OnEntityRemoved(Entity entity)
        {
            if (entity.HasComponent<IsMainHero>())
            {
                _entitiesLifeContext.Removed -= OnEntityRemoved;

                _mainHero = null;

                _heroRemoved?.Invoke(entity);
            }
        }
    }
}