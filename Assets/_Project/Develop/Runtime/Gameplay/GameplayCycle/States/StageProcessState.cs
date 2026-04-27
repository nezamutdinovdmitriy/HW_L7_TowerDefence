using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class StageProcessState : State, IUpdatableState
    {
        private readonly StageProvider _stageProvider;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public StageProcessState(
            StageProvider stageProvider, 
            MainHeroHolderService mainHeroHolderService, 
            EntitiesLifeContext entitiesLifeContext)
        {
            _stageProvider = stageProvider;
            _mainHeroHolderService = mainHeroHolderService;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public override void Enter()
        {
            base.Enter();

            _stageProvider.SwitchToNextStage();
            _stageProvider.StartCurrent();

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
        }
    }
}