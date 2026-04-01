using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
{
    public class ExplosionView : MonoEntityView
    {
        [SerializeField] private ParticleSystem _explosionVfxPrefab;

        private Transform _transform;
        private ReactiveVariable<bool> _isDead;
        private ReactiveVariable<float> _explosionRadius;

        private IDisposable _disposable;

        protected override void OnEntityInitialized(Entity entity)
        {
            _isDead = entity.IsDead;
            _transform = entity.Transfrom;
            _explosionRadius = entity.ExplosionRadius;

            _disposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _disposable?.Dispose();
        }

        private void OnIsDeadChanged(bool arg1, bool isDead) => SpawnParticle(isDead);
        private void SpawnParticle(bool isDead)
        {
            if (isDead)
            {
                ParticleSystem instance = Instantiate(
                      _explosionVfxPrefab,
                      _transform.position,
                      Quaternion.identity,
                      null);

                SetParticleRadiusFor(instance, _explosionRadius.Value);
            }
        }

        private void SetParticleRadiusFor(ParticleSystem particleSystem, float radius)
        {
            ParticleSystem[] childrenSystems = _explosionVfxPrefab.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem child in childrenSystems)
            {
                ParticleSystem.ShapeModule shape = child.shape;
                shape.radius = radius;
            }
        }
    }
}