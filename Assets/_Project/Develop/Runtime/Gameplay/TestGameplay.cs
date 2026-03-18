using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public sealed class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;

        private EntitiesLifeContext _entitiesLifeContext;

        private MainHeroEntityFactory _mainHeroFactory;
        private EnemiesEntityFactory _enemiesFactory;
        private readonly Entity _entity;

        private ScreenToWorldPositionConverter _screenToWorldPositionConverter;
        private IGameplayInputService _input;

        private WalletService _walletService;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;

            _screenToWorldPositionConverter = container.Resolve<ScreenToWorldPositionConverter>();

            _mainHeroFactory = container.Resolve<MainHeroEntityFactory>();
            _enemiesFactory = container.Resolve<EnemiesEntityFactory>();

            _input = container.Resolve<IGameplayInputService>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();

            _walletService = container.Resolve<WalletService>();
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

            if (Input.GetKeyDown(KeyCode.S))
                _walletService.Spend(CurrencyType.Gold, 10);

            if (Input.GetKeyDown(KeyCode.I))
                _walletService.GetCurrency(CurrencyType.Gold);

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