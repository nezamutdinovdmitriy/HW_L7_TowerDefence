using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Explosion
{
    public class ExplosionEndSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _explosionInProcess;
        private ReactiveVariable<float> _explosionDestroyDelay;

        public void OnInitialize(Entity entity)
        {
            _explosionInProcess = entity.ExplosionInProcess;
            _explosionDestroyDelay = entity.ExplosionDestroyDelay;
        }

        public void OnUpdate(float deltaTime)
        {
            _explosionDestroyDelay.Value -= deltaTime;

            if (_explosionDestroyDelay.Value <= 0
                && _explosionInProcess.Value == true)
                _explosionInProcess.Value = false;
        }
    }
}