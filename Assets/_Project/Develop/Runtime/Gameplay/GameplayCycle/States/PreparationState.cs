using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class PreparationState : State, IUpdatableState
    {
        private readonly TimerService _timer;
        private readonly MainHeroHolderService _mainHeroHolderService;

        public PreparationState(TimerService timer, MainHeroHolderService mainHeroHolderService)
        {
            _timer = timer;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public override void Enter()
        {
            base.Enter();

            _timer.Restart();

            _mainHeroHolderService.MainHero.AbilityCurrent.Value = AbilitySlotType.Utility;
        }

        public override void Exit()
        {
            base.Exit();

            _timer.Dispose();
        }

        public void Update(float deltaTime)
        {
        }
    }
}