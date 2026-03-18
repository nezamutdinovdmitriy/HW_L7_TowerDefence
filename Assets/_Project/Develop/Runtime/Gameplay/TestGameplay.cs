using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public sealed class TestGameplay : MonoBehaviour
    {

        private EntitiesLifeContext _entitiesLifeContext;

        private MainHeroEntityFactory _mainHeroFactory;
        private EnemiesEntityFactory _enemiesFactory;

        private WalletService _walletService;

        private PlayerDataProvider _playerDataProvider;
        private ICoroutinesPerformer _coroutinesPerformer;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _mainHeroFactory = container.Resolve<MainHeroEntityFactory>();
            _enemiesFactory = container.Resolve<EnemiesEntityFactory>();

            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();

            _walletService = container.Resolve<WalletService>();

            _playerDataProvider = container.Resolve<PlayerDataProvider>();
            _coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
        }

        public void Run()
        {
            ReactiveVariable<Entity> mainHero = new(_mainHeroFactory.CreateTower(Vector3.zero));
            
            for (int i = 0; i < 2; i++)
            {
                float _spawnRadius = 10f;

                Vector2 randomPosition = Random.insideUnitCircle.normalized * _spawnRadius;

                Vector3 spawnPoint = new(randomPosition.x, 0, randomPosition.y);

                Entity enemy = _enemiesFactory.CreateBaseСreep(spawnPoint);
                enemy.AddCurrentTarget(mainHero);
            }

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.A))
                _walletService.Add(CurrencyType.Gold, 100);

            if (Input.GetKeyDown(KeyCode.I))
                _walletService.GetCurrency(CurrencyType.Gold);

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
            }

            _entitiesLifeContext?.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (_isRunning == false)
                return;

            _entitiesLifeContext?.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}