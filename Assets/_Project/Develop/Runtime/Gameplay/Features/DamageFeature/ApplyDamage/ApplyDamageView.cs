using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage
{
    public class ApplyDamageView : MonoEntityView
    {
        [SerializeField] private ParticleSystem _vfxPrefab;
        [SerializeField] private Transform _hitPoint;

        private ReactiveEvent<float> _takeDamageEvent;
        private IDisposable _disposable;

        protected override void OnEntityInitialized(Entity entity)
        {
            _takeDamageEvent = entity.TakeDamageEvent;

            _disposable = _takeDamageEvent.Subscribe(OnDamaged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _disposable?.Dispose();
        }

        private void OnDamaged(float obj) => Instantiate(_vfxPrefab, _hitPoint.position, Quaternion.identity);
    }
}