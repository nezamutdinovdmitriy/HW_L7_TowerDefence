using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public sealed class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screenView;

        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;

        private readonly MainMenuPopupService _menuPopupService;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screenView,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPresentersFactory menuPresentersFactory,
            MainMenuPopupService menuPopupService)
        {
            _screenView = screenView;
            _projectPresentersFactory = projectPresentersFactory;
            _mainMenuPresentersFactory = menuPresentersFactory;
            _menuPopupService = menuPopupService;
        }

        public void Initialize()
        {            
            CreateWalletPresenter();
            CreateStartGameButtonPresenter();
            CreateUpgradesShopButtonPresenter();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
        }

        private void CreateWalletPresenter()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screenView.WalletView);

            AddChildPresenter(walletPresenter);
        }

        private void CreateStartGameButtonPresenter()
        {
            StartGameButtonPresenter startGameButtonPresenter = _mainMenuPresentersFactory
                .CreateStartGameButtonPresenter(_screenView.StartGameButton);

            AddChildPresenter(startGameButtonPresenter);
        }

        private void CreateUpgradesShopButtonPresenter()
        {
            UpgradesShopButtonPresenter upgradesShopButtonPresenter = _mainMenuPresentersFactory.
                CreateUpgradesShopButtonPresenter(_screenView.UpgradesShopButton);

            AddChildPresenter(upgradesShopButtonPresenter);
        }

        private void AddChildPresenter(IPresenter presenter) => _childPresenters.Add(presenter);
    }
}