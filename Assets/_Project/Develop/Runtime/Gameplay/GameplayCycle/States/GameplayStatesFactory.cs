using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public class GameplayStatesFactory
    {
        private readonly DIContainer _container;

        public GameplayStatesFactory(DIContainer container) => _container = container;

        public GameplayStateMachine CreateGameplayStateMachine(float preparationDuration)
        {
            StageProvider stageProvider = _container.Resolve<StageProvider>();
            MainHeroHolderService mainHeroHolderService = _container.Resolve<MainHeroHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState(preparationDuration);
            DefeatState defeatState = CreateDefeatState();
            WinState winState = CreateWinState();

            ICompositeCondition coreLoopToWin = new CompositeCondition()
                .Add(new FuncCondition(() => stageProvider.CurrentStageResult.Value == StageResult.Completed))
                .Add(new FuncCondition(() => stageProvider.HasNextStage() == false));

            ICompositeCondition coreLoopToDefeat = new CompositeCondition()
                .Add(new FuncCondition(() =>
                {
                    if (mainHeroHolderService.MainHero != null)
                        return mainHeroHolderService.MainHero.IsDead.Value;

                    return false;
                }));

            GameplayStateMachine gameplayCycle = new();

            gameplayCycle.AddState(coreLoopState);
            gameplayCycle.AddState(winState);
            gameplayCycle.AddState(defeatState);

            gameplayCycle.AddTransition(coreLoopState, winState, coreLoopToWin);
            gameplayCycle.AddTransition(coreLoopState, defeatState, coreLoopToDefeat);

            return gameplayCycle;
        }

        public GameplayStateMachine CreateCoreLoopState(float preparationDuration)
        {
            TimerService timerSerivce = _container.Resolve<TimerServiceFactory>().Create(preparationDuration);
            StageProvider stageProvider = _container.Resolve<StageProvider>();

            PreparationState preparationState = CreatePreparationState(timerSerivce);
            StageProcessState stageProcessState = CreateStageProcessState();

            ICompositeCondition preparationToStageProcess = new CompositeCondition()
                .Add(new FuncCondition(() => stageProvider.HasNextStage()))
                .Add(new FuncCondition(() => timerSerivce.IsOver));

            ICompositeCondition stageProcessToPreparation = new CompositeCondition()
                .Add(new FuncCondition(() => stageProvider.CurrentStageResult.Value == StageResult.Completed));

            GameplayStateMachine coreLoopState = new();

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(stageProcessState);

            coreLoopState.AddTransition(preparationState, stageProcessState, preparationToStageProcess);
            coreLoopState.AddTransition(stageProcessState, preparationState, stageProcessToPreparation);

            return coreLoopState;
        }

        public PreparationState CreatePreparationState(TimerService timer)
            => new(
                timer,
                _container.Resolve<MainHeroHolderService>()
                );

        public StageProcessState CreateStageProcessState()
            => new(
                _container.Resolve<StageProvider>(),
                _container.Resolve<MainHeroHolderService>()
                );

        public WinState CreateWinState()
            => new(
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<IGameplayInputService>()
                );

        public DefeatState CreateDefeatState()
            => new(
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<IGameplayInputService>()
                );
    }
}