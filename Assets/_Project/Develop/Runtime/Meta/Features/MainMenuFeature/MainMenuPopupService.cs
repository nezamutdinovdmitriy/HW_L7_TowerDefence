using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public class MainMenuPopupService : PopupService
    {
        private readonly UIRoot _root;
        private readonly MainMenuPresentersFactory _presentersFactory;

        public MainMenuPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            UIRoot root,
            MainMenuPresentersFactory mainMenuPresentersFactory)
            : base(viewsFactory, projectPresentersFactory)
        {
            _root = root;
            _presentersFactory = mainMenuPresentersFactory;
        }

        protected override Transform PopupLayer => _root.PopupsLayer;

        public UpgradesPopupPresenter OpenUpgradesPopupPresenter()
        {
            UpgradesPopupView view = _viewsFactory.Create<UpgradesPopupView>(ViewIDs.UpgradesPopupView, PopupLayer);

            UpgradesPopupPresenter popup = _presentersFactory.CreateUpgradesPopupPresenter(view);

            OnPopupCreated(popup, view);

            return popup;
        }

    }
}