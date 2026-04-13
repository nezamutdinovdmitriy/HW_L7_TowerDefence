using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.TestView
{
    [RequireComponent(typeof(Animator))]
    public class AbilityCastView : MonoEntityView
    {
        [SerializeField] private Animator _animator;

        private AbilityToAnimatorKeyMapping _mapping;

        private ReactiveVariable<bool> _castInProcess;
        private ReactiveVariable<Entity> _currentCastingAbility;

        private IDisposable _disposable;

        protected override void OnEntityInitialized(Entity entity)
        {
            _mapping = entity.AbilityCastKeyMapping;
            _currentCastingAbility = entity.CurrentCastingAbility;
            _castInProcess = entity.AbilityCastInProcess;

            _disposable = _castInProcess.Subscribe(OnCastInProcessChanged);
        }

        private void OnCastInProcessChanged(bool arg1, bool isCasting)
        {
            _mapping.TryGetCastProcessKey(_currentCastingAbility.Value.Ability.Value, out string key);

            _animator.SetBool(key, isCasting);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _disposable?.Dispose();
        }
    }
}