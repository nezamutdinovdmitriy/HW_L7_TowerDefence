using Assets._Project.Develop.Runtime.Gameplay.Configs.Upgrades;
using Assets._Project.Develop.Runtime.Meta.Configs.Wallet;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradeCardPresenter : IPresenter
    {
        private readonly UpgradeCardView _view;
        private readonly UpgradesViewConfig _viewConfig;
        private readonly UpgradesService _upgradeService;
        private readonly WalletService _walletService;
        private readonly UpgradeType _upgradeType;
        private readonly CurrencyIconsConfig _currencyIconsConfig;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private IDisposable _disposables;

        public UpgradeCardPresenter(
            UpgradeCardView view,
            UpgradesViewConfig viewConfig,
            UpgradesService upgradeService,
            WalletService walletService,
            UpgradeType upgradeType,
            CurrencyIconsConfig currencyIconsConfig,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _view = view;
            _viewConfig = viewConfig;
            _upgradeService = upgradeService;
            _walletService = walletService;
            _upgradeType = upgradeType;
            _currencyIconsConfig = currencyIconsConfig;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public UpgradeCardView View => _view;

        public void Initialize()
        {
            UpgradesViewConfig.UpgradeViewData upgradeViewData = _viewConfig.GetConfigBy(_upgradeType);

            _view.SetImage(upgradeViewData.Sprite);

            UpdateDescription(upgradeViewData.Description);

            UpdateBuyButton();
            _view.BuyButtonView.Clicked += OnBuyButtonClicked;

            IReadOnlyVariable<int> currency = _walletService.GetCurrency(_upgradeService.GetUpgradeCostTypeBy(_upgradeType));

            _disposables = currency.Subscribe(OnWalletChanged);
        }

        public void Dispose()
        {
            _view.BuyButtonView.Clicked -= OnBuyButtonClicked;

            _disposables.Dispose();
        }

        private void UpdateDescription(string description)
        {
            if (_upgradeService.AvailableUpgrades.Contains(_upgradeType))
            {
                _view.SetDescription("Already unlocked!");
                return;
            }

            _view.SetDescription(description);
        }

        private void UpdateBuyButton()
        {
            if (_upgradeService.TryGetUpgradeCost(_upgradeType, out CurrencyType currency, out int cost))
            {
                _view.BuyButtonView.SetIcon(_currencyIconsConfig.GetSpriteFor(currency));
                _view.BuyButtonView.ShowIcon();

                _view.BuyButtonView.SetPrice(cost.ToString());
                _view.BuyButtonView.ShowPrice();

                if (_walletService.Enough(currency, cost))
                    _view.BuyButtonView.Unlock();
                else
                    _view.BuyButtonView.Lock();
            }
            else
            {
                _view.BuyButtonView.gameObject.SetActive(false);
            }
        }

        private void OnBuyButtonClicked()
        {
            if (_upgradeService.TryGetUpgradeCost(_upgradeType, out CurrencyType currency, out int cost))
            {
                if (_walletService.Enough(currency, cost))
                {
                    _walletService.Spend(currency, cost);
                    _upgradeService.AddUpgrade(_upgradeType);

                    UpdateDescription("Already unlocked!");
                    UpdateBuyButton();

                    _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
                }
                else
                {
                    Debug.Log("Not enought currency!");
                }
            }
            else
            {
                Debug.Log("Already unlocked!");
            }
        }

        private void OnWalletChanged(int arg1, int arg2) => UpdateBuyButton();
    }
}