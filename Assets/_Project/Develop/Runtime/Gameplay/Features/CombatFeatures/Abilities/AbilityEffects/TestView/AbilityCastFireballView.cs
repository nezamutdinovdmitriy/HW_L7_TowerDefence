using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.TestView
{
    public class AbilityCastFireballView : MonoEntityView
    {
        private readonly int AnimKey = Animator.StringToHash("AbilityCastInProcess");

        [SerializeField] private Animator _animator;

        private ReactiveVariable<bool> _castInProcess;

        private IDisposable _disposable;

        protected override void OnEntityInitialized(Entity entity)
        {
            _castInProcess = entity.AbilityCastInProcess;

            _disposable = _castInProcess.Subscribe(OnCastInProcessChanged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _disposable?.Dispose();
        }

        private void UpdateAnimator(bool value) => _animator.SetBool(AnimKey, value);

        private void OnCastInProcessChanged(bool arg1, bool abilityCastInProcess) => UpdateAnimator(abilityCastInProcess);
    }
}