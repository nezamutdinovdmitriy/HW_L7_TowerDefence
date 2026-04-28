using Assets._Project.Develop.Runtime.UI.Core;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature
{
    public class AbilitySelectButtonView : MonoBehaviour, IView
    {
        public event Action Clicked;

        [SerializeField] private Button _button;

        [Space]

        [SerializeField] private TMP_Text _abilityName;
        [SerializeField] private Image _selectable;

        private Tween _currentAnimation;

        private void OnEnable()
        {
            transform.localScale = Vector3.zero;

            _button.onClick.AddListener(OnClicked);
        }
        private void OnDisable() => _button.onClick.RemoveListener(OnClicked);

        public void SetAbilityName(string abilityName) => _abilityName.text = abilityName;

        public void ShowSelectableGlow() => _selectable.gameObject.SetActive(true);
        public void HideSelectableGlow() => _selectable.gameObject.SetActive(false);

        public Tween Show() => TriggerScaleAnimation(Vector3.one, 0.25f);
        public Tween Hide() => TriggerScaleAnimation(Vector3.zero, 0.25f);

        private void OnClicked() => Clicked?.Invoke();

        private Tween TriggerScaleAnimation(Vector3 endValue, float duration)
        {
            _currentAnimation?.Kill();

            _currentAnimation = transform
                .DOScale(endValue, duration)
                .SetEase(Ease.OutBack);

            return _currentAnimation;
        }
    }
}