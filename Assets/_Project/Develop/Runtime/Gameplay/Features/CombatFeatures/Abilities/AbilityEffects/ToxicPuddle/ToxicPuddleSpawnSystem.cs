using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle
{
    public class ToxicPuddleSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private AbilityEffectsFactory _effectsFactory;
        private ToxicPuddleAbilityConfig _config;

        private ReactiveVariable<bool> _shouldSpawnEffect;

        private Entity _owner;

        public ToxicPuddleSpawnSystem(
            AbilityEffectsFactory effectsFactory, 
            ToxicPuddleAbilityConfig config)
        {
            _effectsFactory = effectsFactory;
            _config = config;
        }

        public void OnInitialize(Entity entity)
        {
            _shouldSpawnEffect = entity.ShouldSpawnEffect;
            _owner = entity.Hierarchy.Value.Parent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_shouldSpawnEffect.Value == false)
                return;

            _effectsFactory.CreateToxicPuddle(_owner, _config);

            _shouldSpawnEffect.Value = false;
        }
    }
}