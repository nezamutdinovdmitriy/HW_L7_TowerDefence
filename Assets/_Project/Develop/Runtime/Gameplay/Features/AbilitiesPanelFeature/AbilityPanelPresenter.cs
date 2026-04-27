using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature
{
    public class AbilityPanelPresenter : IPresenter
    {
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly AbilityPaneltView _abilityPanelView;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private List<AbilitySelectButtonPresenter> _childPresenters = new();

        private IDisposable _disposable;

        public AbilityPanelPresenter(
            MainHeroHolderService mainHeroHolderService,
            AbilityPaneltView abilityPanelView,
            ViewsFactory viewsFactory,
            GameplayPresentersFactory gameplayPresentersFactory)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _abilityPanelView = abilityPanelView;
            _viewsFactory = viewsFactory;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        public void Initialize() => _disposable = _mainHeroHolderService.HeroRegistered.Subscribe(CreatePresenters);

        private void CreatePresenters(Entity entity)
        {
            foreach (var kvp in entity.AbilitiesStorage)
            {
                var slot = kvp.Key;
                var abilities = kvp.Value;

                if (abilities == null)
                    return;

                foreach (var ability in abilities)
                {
                    AbilitySelectButtonView buttonView = _viewsFactory.Create<AbilitySelectButtonView>(ViewIDs.AbilitySelectButtonView);
                    _abilityPanelView.Add(buttonView);

                    AbilitySelectButtonPresenter buttonPresenter = _gameplayPresentersFactory.CreateAbilitySelectButtonPresenter(buttonView, ability);
                    buttonPresenter.Initialize();

                    _childPresenters.Add(buttonPresenter);
                }
            }
        }

        public void Dispose()
        {
            foreach (AbilitySelectButtonPresenter presenter in _childPresenters)
            {
                _abilityPanelView.Remove(presenter.View);
                _viewsFactory.Remove(presenter.View);
                presenter.Dispose();
            }

            _childPresenters.Clear();
            _disposable?.Dispose();
        }
    }
}