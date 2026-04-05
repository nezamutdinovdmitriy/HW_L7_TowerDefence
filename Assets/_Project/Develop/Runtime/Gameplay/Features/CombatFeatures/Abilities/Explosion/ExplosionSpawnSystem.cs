using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public sealed class ExplosionSpawnSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly CombatEntityFactory _combatEntityFactory;
        private readonly float _radius;
        
        private Entity _source;
        private Transform _transform;

        private ICompositeCondition _canSpawnExplosion;

        public ExplosionSpawnSystem(CombatEntityFactory combatEntityFactory, float radius)
        {
            _combatEntityFactory = combatEntityFactory;
            _radius = radius;
        }

        public void OnInitialize(Entity entity)
        {
            _source = entity;
            _transform = entity.Transfrom;
            _canSpawnExplosion = entity.CanSpawnExplosion;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canSpawnExplosion.Evaluate())
            {
                //_combatEntityFactory.CreateExplosion(_transform.position, _source, );
                
                _source.ExplosionRequested.Value = false;
            }
        }
    }
}