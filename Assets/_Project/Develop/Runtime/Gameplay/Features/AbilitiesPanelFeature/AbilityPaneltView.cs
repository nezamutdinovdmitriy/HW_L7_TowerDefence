using Assets._Project.Develop.Runtime.UI.CommonViews;
using DG.Tweening;

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

        public Tween Show()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (AbilitySelectButtonView view in Elements)
                sequence.Join(view.Show());

            sequence.Play();

            return sequence;
        }

        public Tween Hide()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (AbilitySelectButtonView view in Elements)
                sequence.Join(view.Hide());

            sequence.Play();

            return sequence;
        }
    }
}