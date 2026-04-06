using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat
{
    public sealed class ExplosionState : State, IUpdatableState
    {
        private readonly Entity _entity;

        public ExplosionState(Entity entity)
        {
            _entity = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("EXPLOSION STATE ENTERED");

            //_entity.ShouldForceDeath.Value = true;

            _entity.IsDead.Value = true;
            _entity.AbilityUseRequest.Invoke();

            //_entity.ShouldForceDeath.Value = true;

            Debug.Log($"{_entity.IsDead.Value}");
        }

        public void Update(float deltaTime)
        {
        }
    }
}