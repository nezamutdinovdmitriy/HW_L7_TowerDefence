using Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradesPopupPresenter : PopupPresenterBase
    {
        private const string Title = "UPGRADES SHOP";

        private readonly UpgradesPopupView _view;
        private readonly ViewsFactory _viewFactory;
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;

        private readonly List<UpgradeCardPresenter> _cardPresenters = new();

        public UpgradesPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            UpgradesPopupView view,
            ViewsFactory viewFactory,
            MainMenuPresentersFactory mainMenuPresentersFactory
            )
            : base(coroutinesPerformer)
        {
            _view = view;
            _viewFactory = viewFactory;
            _mainMenuPresentersFactory = mainMenuPresentersFactory;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle(Title);

            foreach (UpgradeType upgradeType in Enum.GetValues(typeof(UpgradeType)))
            {
                UpgradeCardView view = _viewFactory.Create<UpgradeCardView>(ViewIDs.UpgradeCardView);
                _view.UpgradesListView.Add(view);

                UpgradeCardPresenter presenter = _mainMenuPresentersFactory.CreateUpgradeCardPresenter(view, upgradeType);
                _cardPresenters.Add(presenter);
                presenter.Initialize();
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (UpgradeCardPresenter presenter in _cardPresenters)
            {
                presenter?.Dispose();
                _view.UpgradesListView.Remove(presenter.View);
                _viewFactory.Remove(presenter.View);
            }

            _cardPresenters.Clear();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (UpgradeCardPresenter presenter in _cardPresenters)
                presenter?.Dispose();
        }
    }
}