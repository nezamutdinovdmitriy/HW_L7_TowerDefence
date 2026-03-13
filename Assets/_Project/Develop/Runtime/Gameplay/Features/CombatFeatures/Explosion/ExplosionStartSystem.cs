using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Explosion
{
    public class ExplosionStartSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _explosionInProcess;

        public void OnInitialize(Entity entity)
        {
            _explosionInProcess = entity.ExplosionInProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            _explosionInProcess.Value = true;
        }
    }
}