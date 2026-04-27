using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public sealed class ViewsFactory
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;

        private readonly Dictionary<string, string> _viewIDToResourcesPath = new()
        {
            {ViewIDs.CurrencyView, "UI/Wallet/CurrencyView" },
            {ViewIDs.GameplayScreen, "UI/Gameplay/GameplayScreenView" },
            {ViewIDs.MainMenuScreen, "UI/MainMenu/MainMenuScreenView" },
            {ViewIDs.WalletView, "UI/Wallet/WalletVIew" },
            {ViewIDs.WinPopup, "UI/Gameplay/ResultsPopup/WinPopup" },
            {ViewIDs.DefeatPopup, "UI/Gameplay/ResultsPopup/DefeatPopup" },
            {ViewIDs.SimpleHealthBar, "UI/Gameplay/HealthBars/SimpleHealthBar" },
            {ViewIDs.TowerHealthBar, "UI/Gameplay/HealthBars/TowerHealthBar" },
            {ViewIDs.UpgradeCardView, "UI/UpgradeFeature/UpgradeCardView" },
            {ViewIDs.UpgradesPopupView, "UI/UpgradeFeature/UpgradesPopupView" },
            {ViewIDs.AbilitySelectButtonView, "UI/Gameplay/AbilitiesPanel/AbilitySelectButtonView" },
            {ViewIDs.AbilityPanelView, "UI/Gameplay/AbilitiesPanel/AbilityPanelView" }
        };

        public ViewsFactory(ResourcesAssetsLoader resourcesAssetsLoader)
            => _resourcesAssetsLoader = resourcesAssetsLoader;

        public TView Create<TView>(string viewID, Transform parent = null) 
            where TView : MonoBehaviour, IView
        {
            if (_viewIDToResourcesPath.TryGetValue(viewID, out string resourcePath) == false)
                throw new ArgumentException($"You didn;t set reource path for {typeof(TView)}, searched id: {viewID}");

            GameObject prefap = _resourcesAssetsLoader.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefap, parent);
            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)} component on view instance");

            return view;
        }

        public void Remove<TView>(TView view) 
            where TView : MonoBehaviour, IView
            => Object.Destroy(view.gameObject);
    }
}