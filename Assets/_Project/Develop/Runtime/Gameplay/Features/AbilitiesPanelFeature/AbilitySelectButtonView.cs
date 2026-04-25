using Assets._Project.Develop.Runtime.UI.Core;
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

        private void OnEnable() => _button.onClick.AddListener(OnClicked);
        private void OnDisable() => _button.onClick.RemoveListener(OnClicked);

        public void SetAbilityName(string abilityName) => _abilityName.text = abilityName;

        public void ShowSelectableGlow() => _selectable.gameObject.SetActive(true);
        public void HideSelectableGlow() => _selectable.gameObject.SetActive(false);

        private void OnClicked() => Clicked?.Invoke();

    }
}