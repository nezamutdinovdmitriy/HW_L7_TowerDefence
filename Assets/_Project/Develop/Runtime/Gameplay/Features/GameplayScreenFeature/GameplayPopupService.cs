using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayPopupService : PopupService
    {
        private UIRoot _root;
        private GameplayPresentersFactory _presentersFactory;

        public GameplayPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            UIRoot root, 
            GameplayPresentersFactory gameplayPresentersFactory)
            : base(viewsFactory, projectPresentersFactory)
        {
            _root = root;
            _presentersFactory = gameplayPresentersFactory;
        }

        protected override Transform PopupLayer => _root.PopupsLayer;

        public WinPopupPresenter OpenWinPopup(Action closedCallback = null)
        {
            WinPopupView view = _viewsFactory.Create<WinPopupView>(ViewIDs.WinPopup, PopupLayer);

            WinPopupPresenter popup = _presentersFactory.CreateWinPopupPresenter(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }

        public DefeatPopupPresenter OpenDefeatPopup(Action closedCallback = null)
        {
            DefeatPopupView view = _viewsFactory.Create<DefeatPopupView>(ViewIDs.DefeatPopup, PopupLayer);

            DefeatPopupPresenter popup = _presentersFactory.CreateDefeatPopupPresenter(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }
    }
}