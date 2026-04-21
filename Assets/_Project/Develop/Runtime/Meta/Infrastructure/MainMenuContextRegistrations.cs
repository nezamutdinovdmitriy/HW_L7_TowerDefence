using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature;
using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
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
            container.RegisterAsSingle(CreateUpgradesService).NonLazy();
        }

        private static void RegisterPresenters(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
        }

        private static UpgradesService CreateUpgradesService(DIContainer container)
            => new(
                container.Resolve<ConfigsProvider>().GetConfig<UpgradesConfig>(),
                container.Resolve<PlayerDataProvider>());

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