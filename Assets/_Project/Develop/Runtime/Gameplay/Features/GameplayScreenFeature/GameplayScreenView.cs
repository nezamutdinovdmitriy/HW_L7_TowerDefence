using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public IconTextView StageView { get; private set; }
        [field: SerializeField] public EntitiesHealthDisplay EntitiesHealthDisplay { get; private set; }
        [field: SerializeField] public AbilityPaneltView AbilityPanelView { get; private set; }
    }
}