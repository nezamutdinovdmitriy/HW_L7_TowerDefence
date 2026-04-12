using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast
{
    public class AbilityCastProcessSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<bool> _shouldStartProcess;
        private ReactiveVariable<bool> _shouldSpawnEffect;

        private ReactiveVariable<float> _processCastInitialTime;
        private ReactiveVariable<float> _processCastCurrentTime;
        private ReactiveVariable<float> _abilityCastSpawnEffectDelay;

        private Entity _owner;
        private bool _effectSpawned;

        private IDisposable _disposable;

        public void OnInitialize(Entity entity)
        {
            _shouldStartProcess = entity.ShouldStartProcess;
            _shouldSpawnEffect = entity.ShouldSpawnEffect;

            _processCastInitialTime = entity.AbilityCastInitialTime;
            _processCastCurrentTime = entity.AbilityCastCurrentTime;
            _abilityCastSpawnEffectDelay = entity.AbilityCastSpawnEffectDelay;

            _owner = entity.Hierarchy.Value.Parent;

            _disposable = _shouldStartProcess.Subscribe(OnStartProcessChanged);
        }

        public void OnDispose() => _disposable?.Dispose();

        public void OnUpdate(float deltaTime)
        {
            if (_shouldStartProcess.Value == false)
                return;

            if (_owner.IsDead.Value)
            {
                FinishCastProcess();
                return;
            }

            _processCastCurrentTime.Value -= deltaTime;

            if (_effectSpawned == false
                && _processCastCurrentTime.Value <= _abilityCastSpawnEffectDelay.Value)
                RequestSpawnEffect();

            if (_processCastCurrentTime.Value <= 0)
                FinishCastProcess();
        }

        private void OnStartProcessChanged(bool arg1, bool shouldStartProcess)
        {
            if (shouldStartProcess == true)
                _processCastCurrentTime.Value = _processCastInitialTime.Value;
        }

        private void FinishCastProcess()
        {
            _processCastCurrentTime.Value = 0;
            _shouldStartProcess.Value = false;
            _owner.AbilityCastInProcess.Value = false;
            _effectSpawned = false;
        }

        private void RequestSpawnEffect()
        {
            _effectSpawned = true;
            _shouldSpawnEffect.Value = true;
        }
    }
}