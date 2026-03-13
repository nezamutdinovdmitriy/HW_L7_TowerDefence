using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Explosion
{
    public class ExplosionStartSystem : IInitializableSystem, IUpdatableSystem
    {
        private ICompositeCondition _canExplode;
        private ReactiveVariable<bool> _explosionInProcess;

        public void OnInitialize(Entity entity)
        {
            _canExplode = entity.CanExplode;
            _explosionInProcess = entity.ExplosionInProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canExplode.Evaluate())
                _explosionInProcess.Value = true;
        }
    }
}