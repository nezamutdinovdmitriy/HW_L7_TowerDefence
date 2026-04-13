using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    [RequireComponent(typeof(Animator))]
    public class WalkingView : MonoEntityView
    {
        private int _animationKeyHash;

        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationKey;

        private ReactiveVariable<bool> _isMoving;

        private IDisposable _disposable;

        protected override void OnEntityInitialized(Entity entity)
        {
            _isMoving = entity.IsMoving;

            _animationKeyHash = Animator.StringToHash(_animationKey);

            _disposable = _isMoving.Subscribe(OnIsMovingChanged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _disposable?.Dispose();
        }

        private void OnIsMovingChanged(bool arg1, bool isMoving)
            => _animator.SetBool(_animationKeyHash, isMoving);
    }
}