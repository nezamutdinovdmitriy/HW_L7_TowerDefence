using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreenPresenter(MainMenuScreenView view)
            => new(
                view,
                _container.Resolve<ProjectPresentersFactory>());
    }
}