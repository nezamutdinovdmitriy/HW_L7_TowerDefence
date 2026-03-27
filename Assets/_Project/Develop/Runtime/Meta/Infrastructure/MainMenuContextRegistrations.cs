using Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public sealed class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            RegisterServices(container);
            RegisterFactories(container);
            RegisterPresenters(container);
        }

        private static void RegisterFactories(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
        }

        private static void RegisterServices(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuUIRoot);
        }

        private static void RegisterPresenters(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
        }

        private static UIRoot CreateMainMenuUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            UIRoot prefab = resourcesAssetsLoader.Load<UIRoot>("UI/UIRoot");

            return Object.Instantiate(prefab);
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer container)
            => new(container);

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer container)
        {
            UIRoot root = container.Resolve<UIRoot>();

            MainMenuScreenView screenView = container.Resolve<ViewsFactory>().Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, root.HUDLayer);

            MainMenuScreenPresenter mainMenuScreenPresenter = container.Resolve<MainMenuPresentersFactory>().CreateMainMenuScreenPresenter(screenView);

            return mainMenuScreenPresenter;
        }
    }
}