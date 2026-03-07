using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature
{
    public sealed class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private Entity _entity;

        public SelfReleaseSystem(EntitiesLifeContext entitiesLifeContext) => _entitiesLifeContext = entitiesLifeContext;

        public void OnInitialize(Entity entity) => _entity = entity;

        public void OnUpdate(float deltaTime)
        {
            if (_entity.MustSelfRelease.Evaluate())
                _entitiesLifeContext.Remove(_entity);
        }
    }
}