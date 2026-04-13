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
        [SerializeField] private Animator _animator;
        private int _animatorKeyHash; 

        private AbilityToAnimatorKeyMapping _mapping;

        private ReactiveVariable<Entity> _currentCastingAbility;
        private Entity _previousAbility;


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
            }

            _animator.SetBool(_animatorKeyHash, value);
        }
    }
}