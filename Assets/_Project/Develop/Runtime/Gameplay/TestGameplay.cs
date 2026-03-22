using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget;
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
        private AIBrainsContext _brainsContext;

        private MainHeroEntityFactory _mainHeroFactory;
        private EnemiesEntityFactory _enemiesFactory;

        private WalletService _walletService;

        private PlayerDataProvider _playerDataProvider;
        private ICoroutinesPerformer _coroutinesPerformer;

        private BrainsFactory _brainsFactory;
        private MainHeroHolderService _mainHeroHolderService;

        private bool _isRunning;

        private ReactiveVariable<Entity> _mainHero = new();

        public void Initialize(DIContainer container)
        {
            _mainHeroFactory = container.Resolve<MainHeroEntityFactory>();
            _enemiesFactory = container.Resolve<EnemiesEntityFactory>();

            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();

            _walletService = container.Resolve<WalletService>();

            _playerDataProvider = container.Resolve<PlayerDataProvider>();
            _coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();

            _mainHeroHolderService = container.Resolve<MainHeroHolderService>();
            _brainsFactory = container.Resolve<BrainsFactory>();

            _brainsContext = container.Resolve<AIBrainsContext>();
        }

        public void Run()
        {
            _mainHero = new(_mainHeroFactory.CreateTower(Vector3.zero));

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.V))
            {
                Vector2 randomPosition = Random.insideUnitCircle.normalized * 35f;

                Vector3 spawnPoint = new(randomPosition.x, 0, randomPosition.y);

                Entity enemy = _enemiesFactory.CreateBaseСreep(spawnPoint);
                enemy.AddCurrentTarget();
                _brainsFactory.CreateBaseEnemyBrain(enemy, new MainHeroTargetSelector(_mainHeroHolderService));
            }

            if (Input.GetKeyDown(KeyCode.A))
                _walletService.Add(CurrencyType.Gold, 100);

            if (Input.GetKeyDown(KeyCode.I))
                _walletService.GetCurrency(CurrencyType.Gold);

            if (Input.GetKeyDown(KeyCode.S))
                _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _entitiesLifeContext?.Update(Time.deltaTime);
            _brainsContext?.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (_isRunning == false)
                return;

            _entitiesLifeContext?.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}