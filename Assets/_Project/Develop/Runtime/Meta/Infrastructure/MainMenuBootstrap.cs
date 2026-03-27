using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public sealed class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private PlayerDataProvider _playerDataProvider;
        private ICoroutinesPerformer _coroutinesPerformer;

        private ViewsFactory _viewsFactory;
        [SerializeField] private Transform _viewsParent;

        private IconTextView _view;
        private ProjectPresentersFactory _projectPresentersFactory;
        private CurrencyPresenter _currencyPresenter;
        private WalletService _walletService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены меню");

            _playerDataProvider = _container.Resolve<PlayerDataProvider>();
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();

            _projectPresentersFactory = _container.Resolve<ProjectPresentersFactory>();
            _viewsFactory = _container.Resolve<ViewsFactory>();
            _walletService = _container.Resolve<WalletService>();

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт сцены меню");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                _currencyPresenter?.Dispose();

                if (_view != null)
                    _viewsFactory.Release(_view);

                _view = _viewsFactory.Create<IconTextView>(ViewIDs.CurrencyView, _viewsParent);

                _currencyPresenter = _projectPresentersFactory.CreateCurrencyPresenter(
                    _view,
                    _walletService.GetCurrency(CurrencyType.Gold),
                    CurrencyType.Gold);

                _currencyPresenter.Initialize();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _walletService.Add(CurrencyType.Gold, 50);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _walletService.Spend(CurrencyType.Gold, 50);
            }


            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(1)));
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
                Debug.Log("Сохранение было вызвано");
            }
        }
    }
}