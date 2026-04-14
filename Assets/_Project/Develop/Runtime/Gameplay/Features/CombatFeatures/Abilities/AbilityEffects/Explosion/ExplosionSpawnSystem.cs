using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public sealed class ExplosionSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly AbilityEffectsFactory _abilityEffectsFactory;

        private Entity _ability;
        private ExplosionConfig _config;
        private Transform _transform;

        private ReactiveVariable<bool> _shouldSpawnEffect;

        public ExplosionSpawnSystem(
            AbilityEffectsFactory abilityEffectsFactory,
            ExplosionConfig config)
        {
            _abilityEffectsFactory = abilityEffectsFactory;
            _config = config;
        }

        public void OnInitialize(Entity entity)
        {
            _ability = entity;
            _transform = entity.Transfrom;

            _shouldSpawnEffect = entity.ShouldSpawnEffect;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_shouldSpawnEffect.Value == false)
                return;

            SpawnEffect();

            _shouldSpawnEffect.Value = false;
        }

        private void SpawnEffect() => _abilityEffectsFactory.CreateExplosion(_transform.position, _ability, _config);
    }
}