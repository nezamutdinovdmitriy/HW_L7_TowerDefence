using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.TestView
{
    [RequireComponent(typeof(Animator))]
    public class AbilityCastView : MonoEntityView
    {
        [SerializeField] private Animator _animator;

        private AbilityToAnimatorKeyMapping _mapping;

        private ReactiveVariable<bool> _castInProcess;

        private Dictionary<AbilitySlotType, Entity> _abilityStorage;
        private ReactiveVariable<AbilitySlotType> _abilitySlotCurrent;

        private int _currentAnimatorHash;
        private int _previousAnimatorHash;

        private List<IDisposable> _disposables = new();

        protected override void OnEntityInitialized(Entity entity)
        {
            _mapping = entity.AbilityCastKeyMapping;

            _abilityStorage = entity.AbilityStorage;
            _abilitySlotCurrent = entity.AbilitySlotCurrent;

            _castInProcess = entity.AbilityCastInProcess;

            _disposables.Add(_castInProcess.Subscribe(OnCastInProcessChanged));
            _disposables.Add(_abilitySlotCurrent.Subscribe(OnAbilitySlotCurrentChanged));
        }

        private void OnAbilitySlotCurrentChanged(AbilitySlotType previous, AbilitySlotType current)
        {
            if (previous == current)
                return;

            GetAbilityAnimatorKeyFor(current);
            SyncCastStateToAnimator();
        }

        private void OnCastInProcessChanged(bool arg1, bool isCasting)
        {
            if(_currentAnimatorHash == 0)
                return;

            _animator.SetBool(_currentAnimatorHash, isCasting);
        }

        private void GetAbilityAnimatorKeyFor(AbilitySlotType currentAbilitySlot)
        {
            if (_abilityStorage.TryGetValue(currentAbilitySlot, out Entity ability) == false)
                return;

            if (_mapping.TryGetCastProcessKey(ability.Ability.Value, out string animatorKey))
            {
                int newHash = Animator.StringToHash(animatorKey);

                if (_previousAnimatorHash != 0 && _previousAnimatorHash != newHash)
                    _animator.SetBool(_previousAnimatorHash, false);

                _previousAnimatorHash = newHash;
                _currentAnimatorHash = newHash;
            }
        }

        private void SyncCastStateToAnimator()
        {
            if (_currentAnimatorHash == 0)
                return;

            _animator.SetBool(_currentAnimatorHash, _castInProcess.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            foreach (IDisposable disposable in _disposables)
                disposable?.Dispose();

            _disposables.Clear();
        }
    }
}