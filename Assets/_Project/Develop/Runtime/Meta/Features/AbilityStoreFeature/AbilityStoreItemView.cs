using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.AbilityStoreFeature
{
    public class AbilityStoreItemView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _description;

        [field: Space]

        [field: SerializeField] public BuyButtonView BuyButtonView { get; private set; }

        public void SetName(string abilityName) => _name.text = abilityName;
        public void SetImage(Sprite abilitySprite) => _image.sprite = abilitySprite;
        public void SetDescription(string description) => _description.text = description;
    }
}