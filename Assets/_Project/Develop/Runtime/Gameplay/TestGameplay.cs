using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public sealed class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;

        private EntitiesLifeContext _entitiesLifeContext;

        private MainHeroEntityFactory _mainHeroFactory;
        private EnemiesEntityFactory _enemiesFactory;
        private Entity _entity;

        private ScreenToWorldPositionConverter _screenToWorldPositionConverter;
        private IGameplayInputService _input;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;

            _screenToWorldPositionConverter = container.Resolve<ScreenToWorldPositionConverter>();
            
            _mainHeroFactory = container.Resolve<MainHeroEntityFactory>();
            _enemiesFactory = container.Resolve<EnemiesEntityFactory>();

            _input = container.Resolve<IGameplayInputService>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
        }

        public void Run()
        {
            _entity = _mainHeroFactory.CreateTower(Vector3.zero);

            //_entity = _enemiesFactory.CreateBaseСreep(Vector3.zero);

            //for (int i = 0; i < 10; i++)
            //{   
            //    float _spawnRadius = 10f;

            //    Vector2 randomPosition = Random.insideUnitCircle.normalized * _spawnRadius;

            //    Vector3 spawnPoint = new (randomPosition.x, 0, randomPosition.y);

            //    _entitiesFactory.CreateBaseСreep(spawnPoint);
            //}

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _entitiesLifeContext?.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _entitiesLifeContext?.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}