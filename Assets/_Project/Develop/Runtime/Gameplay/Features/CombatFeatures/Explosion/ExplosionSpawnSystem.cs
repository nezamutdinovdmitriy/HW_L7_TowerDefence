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

                //DrawExplosionRadius(_entity.Transfrom.position, _radius);
            }
        }

        //private void DrawExplosionRadius(Vector3 center, float radius, int segments = 32)
        //{
        //    float angleStep = 360f / segments;

        //    for (int i = 0; i < segments; i++)
        //    {
        //        float angle1 = Mathf.Deg2Rad * (i * angleStep);
        //        float angle2 = Mathf.Deg2Rad * ((i + 1) * angleStep);

        //        Vector3 p1 = center + new Vector3(Mathf.Cos(angle1) * radius, 0, Mathf.Sin(angle1) * radius);
        //        Vector3 p2 = center + new Vector3(Mathf.Cos(angle2) * radius, 0, Mathf.Sin(angle2) * radius);

        //        Debug.DrawLine(p1, p2, Color.red, 2f);
        //    }
        //}
    }
}