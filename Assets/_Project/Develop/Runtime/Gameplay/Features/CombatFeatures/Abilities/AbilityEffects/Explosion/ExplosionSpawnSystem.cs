using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.Explosion
{
    public class ExplosionSpawnSystem : IUpdatableSystem, IInitializableSystem
    {
        private readonly AbilityEffectsFactory _abilityEffectsFactory;

        private Entity _ability;
        private readonly ExplosionConfig _config;
        private Transform _transform;

        private ICompositeCondition _canExplosion;

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

            _canExplosion = entity.CanSpawnExplosion;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canExplosion.Evaluate() == false)
                return;

            SpawnEffect();
        }

        private void SpawnEffect() => _abilityEffectsFactory.CreateExplosion(_transform.position, _ability, _config);
    }
}