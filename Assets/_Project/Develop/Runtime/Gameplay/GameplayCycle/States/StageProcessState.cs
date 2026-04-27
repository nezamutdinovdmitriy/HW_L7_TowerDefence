using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle;
using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class StageProcessState : State, IUpdatableState
    {
        private readonly StageProvider _stageProvider;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly GameplayScreenPresenter _gameplayScreenPresenter;

        public StageProcessState(
            StageProvider stageProvider,
            MainHeroHolderService mainHeroHolderService,
            EntitiesLifeContext entitiesLifeContext,
            GameplayScreenPresenter gameplayScreenPresenter)
        {
            _stageProvider = stageProvider;
            _mainHeroHolderService = mainHeroHolderService;
            _entitiesLifeContext = entitiesLifeContext;
            _gameplayScreenPresenter = gameplayScreenPresenter;
        }

        public override void Enter()
        {
            base.Enter();

            _stageProvider.SwitchToNextStage();
            _stageProvider.StartCurrent();

            _gameplayScreenPresenter.ScreenView.AbilityPanelView.Hide();
            _gameplayScreenPresenter.ScreenView.AbilityPanelView.gameObject.SetActive(false);

            _mainHeroHolderService.MainHero.AbilitySlotCurrent.Value = AbilitySlotType.Main;
        }

        public void Update(float deltaTime)
            => _stageProvider.UpdateCurrent(deltaTime);

        public override void Exit()
        {
            base.Exit();

            foreach (var entity in _entitiesLifeContext.Entities)
            {
                if (entity.HasComponent<ToxicPuddleRadius>())
                    entity.ShouldForceDeath.Value = true;
            }

            _stageProvider.CleanupCurrent();

            _gameplayScreenPresenter.ScreenView.AbilityPanelView.gameObject.SetActive(true);
            _gameplayScreenPresenter.ScreenView.AbilityPanelView.Show();
        }
    }
}