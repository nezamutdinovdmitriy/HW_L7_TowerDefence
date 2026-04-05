using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public sealed class AbilityUseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly IGameplayInputService _gameplayInputService;

        private Dictionary<AbilityType, Entity> _abilityStorage;
        private ReactiveVariable<AbilityType> _abilityCurrent;

        public AbilityUseSystem(IGameplayInputService gameplayInputService)
            => _gameplayInputService = gameplayInputService;

        public void OnInitialize(Entity entity)
        {
            _abilityStorage = entity.AbilityStorage;
            _abilityCurrent = entity.AbilityCurrent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_gameplayInputService.IsShooting)
                _abilityStorage[_abilityCurrent.Value].AbilityUseRequest.Invoke();
        }
    }
}