using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat
{
    public class AttackState : State, IUpdatableState
    {
        private readonly Entity _entity;

        public AttackState(Entity entity) => _entity = entity;

        public override void Enter()
        {
            base.Enter();

            _entity.ShouldCastAbility.Value = true;
            _entity.InputAimPoint.Value = _entity.CurrentTarget.Value.BodyCollider.bounds.center;
        }

        public void Update(float deltaTime)
        {
            if (_entity.AbilityCastInProcess.Value == true)
            {
                _entity.ShouldCastAbility.Value = false;
                return;
            }

            _entity.ShouldCastAbility.Value = true;
        }
    }
}