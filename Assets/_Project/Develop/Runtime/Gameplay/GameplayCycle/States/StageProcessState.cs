using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class StageProcessState : State, IUpdatableState
    {
        private readonly StageProvider _stageProvider;
        private readonly MainHeroHolderService _mainHeroHolderService;

        public StageProcessState(StageProvider stageProvider, MainHeroHolderService mainHeroHolderService)
        {
            _stageProvider = stageProvider;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public override void Enter()
        {
            base.Enter();

            _stageProvider.SwitchToNextStage();
            _stageProvider.StartCurrent();

            //_mainHeroHolderService.MainHero.AbilityCurrent.Value = AbilitySlotType.Main;
        }

        public void Update(float deltaTime)
            => _stageProvider.UpdateCurrent(deltaTime);

        public override void Exit()
        {
            base.Exit();

            _stageProvider.CleanupCurrent();
        }
    }
}