using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Utilities.Timer;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class PreparationState : State, IUpdatableState
    {
        private readonly TimerService _timer;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly GameplayScreenPresenter _gameplayScreenPresenter;

        public PreparationState(
            TimerService timer, 
            MainHeroHolderService mainHeroHolderService, 
            GameplayScreenPresenter gameplayScreenPresenter)
        {
            _timer = timer;
            _mainHeroHolderService = mainHeroHolderService;
            _gameplayScreenPresenter = gameplayScreenPresenter;
        }

        public override void Enter()
        {
            base.Enter();

            _timer.Restart();

            _gameplayScreenPresenter.ScreenView.AbilityPanelView.gameObject.SetActive(true);
            _gameplayScreenPresenter.ScreenView.AbilityPanelView.Show();

            _mainHeroHolderService.MainHero.AbilitySlotCurrent.Value = AbilitySlotType.Utility;
        }

        public void Update(float deltaTime)
        {
        }

        public override void Exit()
        {
            base.Exit();

            _timer.Dispose();

            _gameplayScreenPresenter.ScreenView.AbilityPanelView.Hide();
            _gameplayScreenPresenter.ScreenView.AbilityPanelView.gameObject.SetActive(false);
        }
    }
}