using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public sealed class UpgradesShopButtonPresenter : IPresenter
    {
        private readonly Button _upgradesShopButtonView;
        private readonly MainMenuPopupService _mainMenuPopupService;

        public UpgradesShopButtonPresenter(
            Button upgradesShopButtonView, 
            MainMenuPopupService mainMenuPopupService)
        {
            _upgradesShopButtonView = upgradesShopButtonView;
            _mainMenuPopupService = mainMenuPopupService;
        }

        public void Initialize() => _upgradesShopButtonView.onClick.AddListener(OnClicked);
        public void Dispose() => _upgradesShopButtonView.onClick.RemoveListener(OnClicked);

        private void OnClicked() => _mainMenuPopupService.OpenUpgradesPopupPresenter();
    }
}