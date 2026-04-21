using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradeCardView : MonoBehaviour, IView
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _description;

        [field: Space]

        [field: SerializeField] public BuyButtonView BuyButtonView { get; private set; }

        public void SetImage(Sprite abilitySprite) => _image.sprite = abilitySprite;
        public void SetDescription(string description) => _description.text = description;
    }
}