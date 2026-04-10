using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayPresentersFactory
    {
        private DIContainer _container;
        private GameplayInputArgs _gameplayInputArgs;

        public GameplayPresentersFactory(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new(view, _container.Resolve<GameplayPresentersFactory>(), _container.Resolve<ProjectPresentersFactory>());

        public StagePresenter CreateStagePresenter(IconTextView view)
            => new(view, _container.Resolve<StageProvider>());

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView view)
            => new(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView view)
            => new(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _gameplayInputArgs);
    }
}