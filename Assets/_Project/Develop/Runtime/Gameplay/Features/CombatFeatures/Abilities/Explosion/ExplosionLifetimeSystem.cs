using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public sealed class ExplosionLifetimeSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _shouldForceDeath;
        private ReactiveVariable<float> _explosionLifetime;

        public void OnInitialize(Entity entity)
        {
            _shouldForceDeath = entity.ShouldForceDeath;
            _explosionLifetime = entity.ExplosionLifetime;
        }

        public void OnUpdate(float deltaTime)
        {
            _explosionLifetime.Value -= deltaTime;

            if (_explosionLifetime.Value <= 0)
                _shouldForceDeath.Value = true;
        }
    }
}