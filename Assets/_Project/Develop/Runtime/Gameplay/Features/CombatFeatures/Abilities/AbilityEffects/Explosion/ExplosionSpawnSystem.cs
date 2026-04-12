using Assets._Project.Develop.Runtime.Gameplay.Configs.Common;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public sealed class ExplosionSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly AbilityEffectsFactory _abilityEffectsFactory;

        private Entity _ability;
        private Entity _owner;

        private ExplosionConfig _config;

        private Transform _transform;

        private ICompositeCondition _canUse;

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

            _owner = entity.Hierarchy.Value.Parent;

            _transform = entity.Transfrom;

            _canUse = entity.CanSpawnExplosion;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canUse.Evaluate())
                _abilityEffectsFactory.CreateExplosion(_transform.position, _ability, _config);
        }
    }
}