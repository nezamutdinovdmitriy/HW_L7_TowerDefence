using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features.WalletFeature
{
    public sealed class WalletPresenter : IPresenter
    {
        private readonly WalletService _walletService;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _listView;

        private readonly List<CurrencyPresenter> _currencyPresenters = new();

        public WalletPresenter(
            WalletService walletService, 
            ProjectPresentersFactory projectPresentersFactory,
            ViewsFactory viewsFactory,
            IconTextListView listView)
        {
            _walletService = walletService;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _listView = listView;
        }

        public void Initialize()
        {
            foreach (CurrencyType currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewIDs.CurrencyView);

                _listView.Add(currencyView);

                CurrencyPresenter currencyPresenter = _projectPresentersFactory.CreateCurrencyPresenter(
                    currencyView,
                    _walletService.GetCurrency(currencyType),
                    currencyType);

                currencyPresenter.Initialize();

                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter currencyPresenter in _currencyPresenters)
            {
                _listView.Remove(currencyPresenter.View);
                _viewsFactory.Release(currencyPresenter.View);
                currencyPresenter.Dispose();
            }

            _currencyPresenters.Clear();
        }
    }
}