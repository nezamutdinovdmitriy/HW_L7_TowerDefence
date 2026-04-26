using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast
{
    [RequireComponent(typeof(Animator))]
    public class AbilityCastView : MonoEntityView
    {
        private const string MultiplierParameterName = "CastingAnimationSpeedMultiplier";
        private readonly int _multiplierParameterHash = Animator.StringToHash(MultiplierParameterName);
        
        private readonly Dictionary<AbilityType, int> _abilityToHashPairs = new();

        [SerializeField] private Animator _animator;

        private ReactiveVariable<Entity> _currentCastingAbility;
        private Entity _previousAbility;

        private IDisposable _disposable;

        private ReactiveVariable<float> AttackPerSecond => _currentCastingAbility.Value.AbilityCastPerSecond;

        protected override void OnEntityInitialized(Entity entity)
        {
            AbilityToAnimatorKeyMapping mapping = entity.AbilityCastKeyMapping;

            _currentCastingAbility = entity.CurrentCastingAbility;

            foreach (KeyValuePair<AbilityType, string> ability in mapping.AbilityToKeys)
                _abilityToHashPairs.Add(
                    ability.Key,
                    Animator.StringToHash(ability.Value));

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
                _previousAbility = _currentCastingAbility.Value;

                UpdateMultiplier();
            }

            int animationHash = _abilityToHashPairs[_currentCastingAbility.Value.Ability.Value];

            _animator.SetBool(animationHash, value);
        }

        private void UpdateMultiplier()
        {
            float initialTime = _currentCastingAbility.Value.AbilityCastInitialTime.Value;
            float spawnEffectDelay = _currentCastingAbility.Value.AbilityCastSpawnEffectDelay.Value;

            float totalBaseTime = initialTime;

            float targetTotalTime = 1f / AttackPerSecond.Value;

            float totalTimeRatio = targetTotalTime / totalBaseTime;


            _currentCastingAbility.Value.AbilityCastModifiedTime.Value =
                initialTime * totalTimeRatio;

            _currentCastingAbility.Value.AbilityCastSpawnEffectDelayModified.Value =
                spawnEffectDelay * totalTimeRatio;

            _animator.SetFloat(
                _multiplierParameterHash,
                initialTime / _currentCastingAbility.Value.AbilityCastModifiedTime.Value);
        }
    }
}