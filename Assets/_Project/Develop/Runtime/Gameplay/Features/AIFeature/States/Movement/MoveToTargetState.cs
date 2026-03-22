using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Movement
{
    public sealed class MoveToTargetState : State, IUpdatableState
    {
        private readonly Entity _entity;

        public MoveToTargetState(Entity entity) => _entity = entity;

        public void Update(float deltaTime)
        {
            _entity.InputMovementDirection.Value = GetDirection();
        }

        public override void Exit()
        {
            base.Exit();
            _entity.InputMovementDirection.Value = Vector3.zero;
        }

        private Vector3 GetDirection()
        {
            Vector3 direction = (_entity.CurrentTarget.Value.BodyTransform.position - _entity.Transfrom.position).normalized;
            direction.y = 0;

            return direction;
        }
    }
}