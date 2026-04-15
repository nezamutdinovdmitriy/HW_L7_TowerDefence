using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.Explosion
{
    public class ExplosionConsumeSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _shouldSpawnEffect;
        private ReactiveVariable<bool> _shouldCastAbility;
        private ReactiveVariable<bool> _shouldStartProcess;

        public void OnInitialize(Entity entity)
        {
            _shouldSpawnEffect = entity.ShouldSpawnEffect;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_shouldSpawnEffect.Value == false)
                return;

            _shouldSpawnEffect.Value = false;
        }
    }
}