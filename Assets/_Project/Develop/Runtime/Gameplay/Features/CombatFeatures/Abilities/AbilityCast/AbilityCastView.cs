using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast
{
    [RequireComponent(typeof(Animator))]
    public class AbilityCastView : MonoEntityView
    {
        private const string MultiplierParameterName = "CastingAnimationSpeedMultiplier";
        private int _multiplierParameterHash = Animator.StringToHash(MultiplierParameterName);

        [SerializeField] private Animator _animator;
        private int _animatorKeyHash;

        private AbilityToAnimatorKeyMapping _mapping;

        private ReactiveVariable<Entity> _currentCastingAbility;
        private Entity _previousAbility;

        private ReactiveVariable<float> _attackPerSecond => _currentCastingAbility.Value.AbilityCastPerSecond;

        private IDisposable _disposable;

        protected override void OnEntityInitialized(Entity entity)
        {
            _mapping = entity.AbilityCastKeyMapping;
            _currentCastingAbility = entity.CurrentCastingAbility;

            _disposable = entity.AbilityCastInProcess.Subscribe(OnCastInProcessChanged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _disposable?.Dispose();
        }

        private void OnCastInProcessChanged(bool arg1, bool value)
        {
            if (_currentCastingAbility.Value != _previousAbility)
            {
                _mapping.TryGetCastProcessKey(_currentCastingAbility.Value.Ability.Value, out string key);
                _previousAbility = _currentCastingAbility.Value;

                _animatorKeyHash = Animator.StringToHash(key);

                UpdateMultiplier();
            }

            _animator.SetBool(_animatorKeyHash, value);
        }

        private void UpdateMultiplier()
        {
            float totalBaseTime = _currentCastingAbility.Value.AbilityCastInitialTime.Value;

            float targetTotalTime = 1f / _attackPerSecond.Value;

            float totalTimeRatio = targetTotalTime / totalBaseTime;

            _currentCastingAbility.Value.AbilityCastModifiedTime.Value = 
                _currentCastingAbility.Value.AbilityCastInitialTime.Value * totalTimeRatio;
            
            _currentCastingAbility.Value.AbilityCastSpawnEffectDelayModified.Value = 
                _currentCastingAbility.Value.AbilityCastSpawnEffectDelay.Value * totalTimeRatio;

            _animator.SetFloat(
                _multiplierParameterHash,
                _currentCastingAbility.Value.AbilityCastInitialTime.Value / _currentCastingAbility.Value.AbilityCastModifiedTime.Value);
        }
    }
}