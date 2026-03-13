using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Explosion
{
    public class ExplosionSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private CombatEntityFactory _combatEntityFactory;
        private Entity _entity;
        private float _radius;

        public ExplosionSpawnSystem(CombatEntityFactory combatEntityFactory, float radius)
        {
            _combatEntityFactory = combatEntityFactory;
            _radius = radius;
        }

        public void OnInitialize(Entity entity)
        {
            _entity = entity;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_entity.MustSelfRelease.Evaluate())
            {
                _combatEntityFactory.CreateExplosion(_entity.Transfrom.position, _radius, _entity);
                Debug.Log($"Заспавнен взрыв радиусом {_radius}");
            }
        }
    }
}