using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States
{
    public class EmptyState : State, IUpdatableState
    {
        public void Update(float deltaTime) { }
    }
}