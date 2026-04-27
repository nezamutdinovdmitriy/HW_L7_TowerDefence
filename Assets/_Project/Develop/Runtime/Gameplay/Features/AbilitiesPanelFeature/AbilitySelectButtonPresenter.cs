using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.UI.Core;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature
{
    public class AbilitySelectButtonPresenter : IPresenter
    {
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly Entity _ability;

        public AbilitySelectButtonPresenter(
            AbilitySelectButtonView view,
            MainHeroHolderService mainHeroHolderService,
            Entity ability)
        {
            View = view;
            _mainHeroHolderService = mainHeroHolderService;
            _ability = ability;
        }

        public Entity MainHero => _mainHeroHolderService.MainHero;

        public AbilitySelectButtonView View { get; }

        public void Initialize()
        {
            View.SetAbilityName(_ability.Ability.Value.ToString());

            View.Clicked += OnViewClicked;
        }

        public void Dispose() => View.Clicked -= OnViewClicked;

        private void OnViewClicked() => MainHero.AbilitiesEquipped[AbilitySlotType.Utility] = _ability;
    }
}