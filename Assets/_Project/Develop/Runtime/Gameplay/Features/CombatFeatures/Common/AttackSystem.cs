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

        public void OnInitialize(Entity entity) => _entity = entity;

        public void OnUpdate(float deltaTime)
        {
            if (_gameplayInputService.IsShooting)
            {
                Vector3 aimPoint = _positionConverter.GetPosition(_gameplayInputService.Aiming.Value);
                Vector3 direction = (aimPoint - _entity.ShootPoint.position).normalized;

                _combatEntityFactory.CreateFireBall(_entity.ShootPoint.position, direction, _entity);
            }
        }
    }
}