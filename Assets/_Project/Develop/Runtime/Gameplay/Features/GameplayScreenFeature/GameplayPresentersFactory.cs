using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayPresentersFactory
    {
        private DIContainer _container;

        public GameplayPresentersFactory(DIContainer container) => _container = container;

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new(view, _container.Resolve<GameplayPresentersFactory>(), _container.Resolve<ProjectPresentersFactory>());

        public StagePresenter CreateStagePresenter(IconTextView view)
            => new(view, _container.Resolve<StageProvider>());
    }
}