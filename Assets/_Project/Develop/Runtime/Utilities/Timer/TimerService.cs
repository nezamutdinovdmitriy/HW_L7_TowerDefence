using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Timer
{
    public sealed class TimerService : IDisposable
    {
        private readonly ReactiveEvent _cooldownEndedEvent;
        
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        
        private readonly float _cooldown;

        private readonly ReactiveVariable<float> _currentTime;
        private Coroutine _cooldownProcess;

        public TimerService(
            float cooldown,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _cooldown = cooldown;
            _coroutinesPerformer = coroutinesPerformer;

            _cooldownEndedEvent = new ReactiveEvent();
            _currentTime = new ReactiveVariable<float>();
        }

        public IReadOnlyEvent CooldownEndedEvent => _cooldownEndedEvent;
        public IReadOnlyVariable<float> CurrentTime => _currentTime;
        public bool IsOver => _currentTime.Value <= 0;

        public void Dispose() => Stop();

        public void Stop()
        {
            if (_cooldownProcess != null)
                _coroutinesPerformer.StopPerform(_cooldownProcess); 
        }
        
        public void Restart()
        {
            Stop();
            _cooldownProcess = _coroutinesPerformer.StartPerform(CooldownProcess());
        }

        private IEnumerator CooldownProcess()
        {
            _currentTime.Value = _cooldown;

            while(IsOver == false)
            {
                _currentTime.Value -= Time.deltaTime;
                yield return null;
            }

            _cooldownEndedEvent?.Invoke();
        }
    }
}