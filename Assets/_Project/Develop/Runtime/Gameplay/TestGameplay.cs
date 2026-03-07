using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public sealed class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;

        private EntitiesLifeContext _entitiesLifeContext;

        private EntitiesFactory _entitiesFactory;
        private Entity _entity;

        private GameObject _sphere;

        private ScreenToWorldPositionConverter _screenToWorldPositionConverter;
        private IGameplayInputService _input;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;

            _screenToWorldPositionConverter = container.Resolve<ScreenToWorldPositionConverter>();
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _input = container.Resolve<IGameplayInputService>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
        }

        public void Run()
        {
            //_entity = _entitiesFactory.CreateTower(Vector3.zero);

            _entity = _entitiesFactory.CreateBaseСreep(Vector3.zero);

            //_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _entitiesLifeContext.Update(Time.deltaTime);

            //_sphere.transform.position = _screenToWorldPositionConverter.GetPosition(_input.Aiming.Value, _entity.Transfrom.position.y);
        }
    }
}