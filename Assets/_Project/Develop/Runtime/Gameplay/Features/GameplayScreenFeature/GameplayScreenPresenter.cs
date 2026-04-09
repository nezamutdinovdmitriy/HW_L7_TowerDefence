using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screenView;

        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView screenView,
            GameplayPresentersFactory gameplayPresentersFactory,
            ProjectPresentersFactory projectPresentersFactory)
        {
            _screenView = screenView;
            _gameplayPresentersFactory = gameplayPresentersFactory;
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
            AddChildPresenter(walletPresenter);
        }

        private void AddChildPresenter(IPresenter presenter) => _childPresenters.Add(presenter);
    }
}