using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using System;
using System.Collections.Generic;
using static Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades.UpgradesViewConfig;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradesPopupPresenter : PopupPresenterBase
    {
        private const string Title = "UPGRADES SHOP";

        private readonly UpgradesPopupView _view;
        private readonly ViewsFactory _viewFactory;
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;
        private readonly UpgradesViewConfig _viewConfig;

        private readonly List<UpgradeCardPresenter> _cardPresenters = new();

        public UpgradesPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            UpgradesPopupView view,
            ViewsFactory viewFactory,
            MainMenuPresentersFactory mainMenuPresentersFactory,
            UpgradesViewConfig viewConfig)
            : base(coroutinesPerformer)
        {
            _view = view;
            _viewFactory = viewFactory;
            _mainMenuPresentersFactory = mainMenuPresentersFactory;
            _viewConfig = viewConfig;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle(Title);

            foreach (UpgradeViewData upgradeData in _viewConfig.Upgrades)
            {
                UpgradeCardView view = _viewFactory.Create<UpgradeCardView>(ViewIDs.UpgradeCardView);
                _view.UpgradesListView.Add(view);

                UpgradeCardPresenter presenter = _mainMenuPresentersFactory.CreateUpgradeCardPresenter(view, upgradeData.Type);
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