using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public sealed class ExplosionLifetimeSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _shouldForceDeath;

        public void OnInitialize(Entity entity)
        {
            _shouldForceDeath = entity.ShouldForceDeath;

            _shouldForceDeath.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
        }
    }
}