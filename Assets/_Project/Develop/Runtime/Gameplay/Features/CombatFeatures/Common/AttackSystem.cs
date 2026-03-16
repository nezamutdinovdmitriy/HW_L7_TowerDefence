using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public class AttackSystem : IInitializableSystem, IUpdatableSystem
    {
        private Entity _entity;

        private CombatEntityFactory _combatEntityFactory;
        private IGameplayInputService _gameplayInputService;
        private ScreenToWorldPositionConverter _positionConverter;

        public AttackSystem(
            CombatEntityFactory combatEntityFactory,
            IGameplayInputService gameplayInputService,
            ScreenToWorldPositionConverter positionConverter)
        {
            _combatEntityFactory = combatEntityFactory;
            _gameplayInputService = gameplayInputService;
            _positionConverter = positionConverter;
        }

        public void OnInitialize(Entity entity)
            => _entity = entity;

        public void OnUpdate(float deltaTime)
        {
            if (_gameplayInputService.IsShooting
                && _positionConverter
                .TryGetPosition(_gameplayInputService.Aiming.Value, out Vector3 worldPosition))
            {
                Vector3 aimPoint = worldPosition;
                Vector3 direction = (aimPoint - _entity.ShootPoint.position).normalized;

                _combatEntityFactory.CreateArcaneMine(aimPoint, 3, 5, _entity);
                //_combatEntityFactory.CreateFireBall(_entity.ShootPoint.position, direction, _entity);
            }

            if (Input.GetKeyDown(KeyCode.Mouse2) && _positionConverter
                .TryGetPosition(_gameplayInputService.Aiming.Value, out Vector3 worldPosition2))
            {
                Vector3 aimPoint = worldPosition2;
                Vector3 direction = (aimPoint - _entity.ShootPoint.position).normalized;

                _combatEntityFactory.CreateFireBall(_entity.ShootPoint.position, direction, _entity);
            }
        }
    }
}