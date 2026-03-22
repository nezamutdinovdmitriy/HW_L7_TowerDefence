using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature
{
    public class AIParallelState : ParallelState<IUpdatableState>, IUpdatableState
    {
        public AIParallelState(params IUpdatableState[] states) : base(states) { }

        public void Update(float deltaTime)
        {
            foreach (IUpdatableState state in States)
                state.Update(deltaTime);
        }
    }
}