using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public class AbilityUseSystem : IInitializableSystem, IUpdatableSystem
    {
        private Dictionary<AbilityType, ReactiveEvent> _abilityStorage;
        private ReactiveVariable<AbilityType> _abilityCurrent;

        private IGameplayInputService _gameplayInputService;

        public AbilityUseSystem(IGameplayInputService gameplayInputService)
            => _gameplayInputService = gameplayInputService;

        public void OnInitialize(Entity entity)
        {
            _abilityStorage = entity.AbilityStorage;
            _abilityCurrent = entity.AbilityCurrent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _abilityCurrent.Value = AbilityType.Main;

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _abilityCurrent.Value = AbilityType.Utility;

            if (_gameplayInputService.IsShooting)
                _abilityStorage[_abilityCurrent.Value].Invoke();
        }
    }
}