using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature
{
    public class AbilityPanelPresenter : IPresenter
    {
        private readonly LevelConfig _levelConfig;
        private readonly AbilityPaneltView _abilityPanelView;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private List<AbilitySelectButtonPresenter> _childPresenters = new();

        public AbilityPanelPresenter(
            LevelConfig levelConfig,
            AbilityPaneltView abilityPanelView,
            ViewsFactory viewsFactory,
            GameplayPresentersFactory gameplayPresentersFactory)
        {
            _levelConfig = levelConfig;
            _abilityPanelView = abilityPanelView;
            _viewsFactory = viewsFactory;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        public void Initialize()
        {
            foreach (AbilityConfig abilityConfig in _levelConfig.AvailableAbilities)
            {
                AbilitySelectButtonView buttonView = _viewsFactory.Create<AbilitySelectButtonView>(ViewIDs.AbilitySelectButtonView);
                _abilityPanelView.Add(buttonView);

                AbilitySelectButtonPresenter buttonPresenter = _gameplayPresentersFactory.CreateAbilitySelectButtonPresenter(buttonView, abilityConfig);
                buttonPresenter.Initialize();

                _childPresenters.Add(buttonPresenter);
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
        }
    }
}