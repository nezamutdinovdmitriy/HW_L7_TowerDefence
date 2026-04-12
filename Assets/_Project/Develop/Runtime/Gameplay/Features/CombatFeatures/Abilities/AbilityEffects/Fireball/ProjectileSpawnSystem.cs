using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball
{
    public class ProjectileSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private AbilityEffectsFactory _effectFactory;
        private FireballAbilityConfig _config;

        private ReactiveVariable<bool> _shouldSpawnEffect;

        private Entity _owner;

        public ProjectileSpawnSystem(AbilityEffectsFactory effectFactory, FireballAbilityConfig config)
        {
            _effectFactory = effectFactory;
            _config = config;
        }

        public void OnInitialize(Entity entity)
        {
            _owner = entity.Hierarchy.Value.Parent;

            _shouldSpawnEffect = entity.ShouldSpawnEffect;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_shouldSpawnEffect.Value == false)
                return;

            SpawnProjectile();

            _shouldSpawnEffect.Value = false;
        }

        private void SpawnProjectile() => _effectFactory.CreateFireBall(_owner, _config);
    }
}