using Assets._Project.Develop.Runtime.UI.CommonViews;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature
{
    public class AbilityPaneltView : ElementsListView<AbilitySelectButtonView>
    {
        public void Select(AbilitySelectButtonView abilitySelectButtonView)
        {
            foreach(AbilitySelectButtonView view in Elements)
                view.HideSelectableGlow();

            abilitySelectButtonView.ShowSelectableGlow();
        }

        public void Show()
        {
            foreach (AbilitySelectButtonView view in Elements)
                view.Show();
        }

        public void Hide()
        {
            foreach (AbilitySelectButtonView view in Elements)
                view.Hide();
        }
    }
}