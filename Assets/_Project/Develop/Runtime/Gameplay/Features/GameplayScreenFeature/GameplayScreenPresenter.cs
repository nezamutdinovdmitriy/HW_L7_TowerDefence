using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screenView;

        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private EntitiesHealthDisplayPresenter _entitiesHealthDisplayPresenter;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView screenView,
            GameplayPresentersFactory gameplayPresentersFactory,
            ProjectPresentersFactory projectPresentersFactory)
        {
            _screenView = screenView;
            _gameplayPresentersFactory = gameplayPresentersFactory;
            _projectPresentersFactory = projectPresentersFactory;
        }

        public void Initialize()
        {
            CreateWalletPresenter();
            CreateStagePresenter();
            CreateEntitiesHealthDisplayPresenter();
            CreateAbilityPanelPresenter();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
        }

        public void LateUpdate()
        {
            _entitiesHealthDisplayPresenter.LateUpdate();
        }

        private void CreateAbilityPanelPresenter()
        {
            AbilityPanelPresenter abilityPanelPresenter = _gameplayPresentersFactory.CreateAbilityPanelPresenter(_screenView.AbilityPanelView);
            AddChildPresenter(abilityPanelPresenter);
        }

        private void CreateStagePresenter()
        {
            StagePresenter stagePresenter = _gameplayPresentersFactory.CreateStagePresenter(_screenView.StageView);
            AddChildPresenter(stagePresenter);
        }

        private void CreateWalletPresenter()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screenView.WalletView);
            AddChildPresenter(walletPresenter);
        }

        private void AddChildPresenter(IPresenter presenter) => _childPresenters.Add(presenter);

        private void CreateEntitiesHealthDisplayPresenter()
        {
            _entitiesHealthDisplayPresenter = _gameplayPresentersFactory.CreateEntitiesHealthDisplayPresenter(_screenView.EntitiesHealthDisplay);

            _childPresenters.Add(_entitiesHealthDisplayPresenter);
        }
    }
}