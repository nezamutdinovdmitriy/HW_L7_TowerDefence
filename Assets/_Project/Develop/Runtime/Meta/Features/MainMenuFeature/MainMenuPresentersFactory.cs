using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.Configs.Wallet;
using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public sealed class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public UpgradeCardPresenter CreateUpgradeCardPresenter(UpgradeCardView view, UpgradeType upgradeType)
            => new(
                view,
                _container.Resolve<ConfigsProvider>().GetConfig<UpgradesViewConfig>(),
                _container.Resolve<UpgradesService>(),
                _container.Resolve<WalletService>(),
                upgradeType,
                _container.Resolve<ConfigsProvider>().GetConfig<CurrencyIconsConfig>());

        public MainMenuScreenPresenter CreateMainMenuScreenPresenter(MainMenuScreenView view)
            => new(
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                this);

        public StartGameButtonPresenter CreateStartGameButtonPresenter(Button view)
            => new(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<ConfigsProvider>().GetConfig<LevelsListConfig>());
    }
}