using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature
{
    public class AbilitySelectButtonPresenter : IPresenter
    {
        public event Action<AbilitySelectButtonPresenter> Selected;

        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly AbilityFactory _abilityFactory;

        public AbilitySelectButtonPresenter(
            AbilitySelectButtonView view,
            AbilityConfig abilityConfig,
            MainHeroHolderService mainHeroHolderService,
            AbilityFactory abilityFactory)
        {
            View = view;
            AbilityConfig = abilityConfig;
            _mainHeroHolderService = mainHeroHolderService;
            _abilityFactory = abilityFactory;
        }

        public Entity MainHero => _mainHeroHolderService.MainHero;

        public AbilitySelectButtonView View { get; }
        public AbilityConfig AbilityConfig { get; }

        public void Initialize()
        {
            View.SetAbilityName(AbilityConfig.AbilityData.AbilityType.ToString());

            View.Clicked += OnViewClicked;
        }

        public void Dispose() => View.Clicked -= OnViewClicked;

        private void OnViewClicked()
        {
            Debug.Log(AbilityConfig.AbilityData.AbilityType.ToString());
            MainHero.AbilityStorage[AbilitySlotType.Utility] = _abilityFactory.Create(AbilityConfig, MainHero);

            Debug.Log("Актуальная абилка в слоте: " + MainHero.AbilityStorage[AbilitySlotType.Utility].Ability.Value);
        }
    }
}