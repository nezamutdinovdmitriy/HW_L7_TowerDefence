using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature
{
    public sealed class UpgradesPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _title;

        [field: SerializeField] public IconTextListView WalletListView;
        [field: SerializeField] public UpgradesListView ItemListView;

        public void SetTitle(string title) => _title.text = title;
    }
}