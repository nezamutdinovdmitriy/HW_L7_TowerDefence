using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public abstract class EndGameState : State
    {
        private readonly IGameplayInputService _inputService;

        protected EndGameState(IGameplayInputService inputService) 
            => _inputService = inputService;

        public override void Enter()
        {
            base.Enter();

            _inputService.IsEnabled = false;
        }

        public override void Exit()
        {
            base.Exit();

            _inputService.IsEnabled = true;
        }
    }
}