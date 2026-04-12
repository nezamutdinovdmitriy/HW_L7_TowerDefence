using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public sealed class ArcaneMineSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly AbilityEffectsFactory _combatEntityFactory;

        private ArcaneMineAbilityConfig _config;

        private ReactiveVariable<bool> _shouldSpawnEffect;

        private Entity _owner;

        private ICompositeCondition _canUse;

        public ArcaneMineSpawnSystem(AbilityEffectsFactory combatEntityFactory, ArcaneMineAbilityConfig config)
        {
            _combatEntityFactory = combatEntityFactory;
            _config = config;
        }

        public void OnInitialize(Entity entity)
        {
            _owner = entity.Hierarchy.Value.Parent;
            _canUse = entity.CanUseArcaneMine;
            _shouldSpawnEffect = entity.ShouldSpawnEffect;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_shouldSpawnEffect.Value == false)
                return;

            if (_canUse.Evaluate() == false)
                return;

            SpawnEffect();

            _shouldSpawnEffect.Value = false;
        }

        private void SpawnEffect() => _combatEntityFactory.CreateArcaneMine(_owner, _config);
    }
}