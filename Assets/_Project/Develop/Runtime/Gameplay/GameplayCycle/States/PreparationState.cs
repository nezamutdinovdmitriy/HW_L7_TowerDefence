using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Utilities.Timer;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public class PreparationState : State, IUpdatableState
    {
        private readonly TimerService _timer;

        public PreparationState(TimerService timer) => _timer = timer;

        public override void Enter()
        {
            base.Enter();

            _timer.Restart();
        }

        public override void Exit()
        {
            base.Exit();

            _timer.Dispose();
        }

        public void Update(float deltaTime)
        {
        }
    }
}