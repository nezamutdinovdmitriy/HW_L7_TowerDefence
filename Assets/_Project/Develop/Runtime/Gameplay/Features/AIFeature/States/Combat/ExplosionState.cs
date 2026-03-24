using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat
{
    public class ExplosionState : State, IUpdatableState
    {
        private readonly Entity _entity;

        public ExplosionState(Entity entity)
        {
            _entity = entity;
        }

        public override void Enter()
        {
            base.Enter();

            _entity.ExplosionRequested.Value = true;
            _entity.ShouldForceDeath.Value = true;
        }

        public void Update(float deltaTime)
        {
        }
    }
}