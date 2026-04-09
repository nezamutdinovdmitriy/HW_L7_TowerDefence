using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayPresentersFactory
    {
        private DIContainer _container;

        public GameplayPresentersFactory(DIContainer container) => _container = container;

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new(view, _container.Resolve<GameplayPresentersFactory>(), _container.Resolve<ProjectPresentersFactory>());
    }
}