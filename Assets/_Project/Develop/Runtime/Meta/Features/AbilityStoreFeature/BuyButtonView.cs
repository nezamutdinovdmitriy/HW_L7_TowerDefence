using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.AbilityStoreFeature
{
    public class BuyButtonView : MonoBehaviour, IView
    {
        public event Action Clicked;

        [SerializeField] private Button _button;
        [SerializeField] private Image _background;
        [SerializeField] private Sprite _availableSprite;
        [SerializeField] private Sprite _lockedSprite;

        [Space]

        [SerializeField] private Image _priceIcon;
        [SerializeField] private TMP_Text _priceText;

        private void OnEnable() => _button.onClick.AddListener(OnButtonClicked);
        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClicked);

        public void Lock() => _background.sprite = _lockedSprite;
        public void Unlock() => _background.sprite = _availableSprite;

        public void SetIcon(Sprite sprite) => _priceIcon.sprite = sprite;
        public void SetPrice(string price) => _priceText.text = price;

        public void HideIcon() => _priceIcon.gameObject.SetActive(false);
        public void ShpwIcon() => _priceIcon.gameObject.SetActive(true);

        private void OnButtonClicked() => Clicked?.Invoke();
    }
}