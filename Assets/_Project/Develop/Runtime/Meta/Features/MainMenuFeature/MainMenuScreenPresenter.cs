using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screenView;

        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screenView, 
            ProjectPresentersFactory projectPresentersFactory)
        {
            _screenView = screenView;
            _projectPresentersFactory = projectPresentersFactory;
        }

        public void Initialize()
        {
            CreateWalletPresenter();

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

            _childPresenters.Add(walletPresenter);
        }
    }
}