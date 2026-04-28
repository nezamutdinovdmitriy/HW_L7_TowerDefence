using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public sealed class ArcaneMineSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly AbilityEffectsFactory _combatEntityFactory;
        private readonly ArcaneMineAbilityConfig _config;

        private Entity _owner;
        private Entity _sourceAbility;

        private ReactiveVariable<bool> _shouldSpawnEffect;
        private ReactiveVariable<bool> _shouldSpendCost;
        private ICompositeCondition _canUse;

        public ArcaneMineSpawnSystem(
            AbilityEffectsFactory combatEntityFactory,
            Entity sourceAbility,
            ArcaneMineAbilityConfig config)
        {
            _combatEntityFactory = combatEntityFactory;
            _sourceAbility = sourceAbility;
            _config = config;
        }

        public void OnInitialize(Entity entity)
        {
            _owner = entity.Hierarchy.Value.Parent;
            _canUse = entity.CanUseArcaneMine;
            _shouldSpawnEffect = entity.ShouldSpawnEffect;
            _shouldSpendCost = entity.ShouldSpendCost;
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

        private void SpawnEffect() => _combatEntityFactory.CreateArcaneMine(_owner, _sourceAbility, _config);
    }
}