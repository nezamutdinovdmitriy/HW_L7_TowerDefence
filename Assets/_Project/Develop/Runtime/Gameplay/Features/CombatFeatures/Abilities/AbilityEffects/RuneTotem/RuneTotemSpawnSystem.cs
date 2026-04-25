using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.RuneTotem
{
    public class RuneTotemSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private AbilityEffectsFactory _effectsFactory;
        private RuneTotemAbilityConfig _config;

        private ReactiveVariable<bool> _shouldSpawnEffect;

        private Entity _owner;

        public RuneTotemSpawnSystem(
            AbilityEffectsFactory effectsFactory,
            RuneTotemAbilityConfig config)
        {
            _effectsFactory = effectsFactory;
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

            // метод создания эффекта абилки

            _shouldSpawnEffect.Value = false;
        }
    }
}