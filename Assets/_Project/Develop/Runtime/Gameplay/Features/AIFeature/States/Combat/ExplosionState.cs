using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat
{
    public sealed class ExplosionState : State, IUpdatableState
    {
        private readonly Entity _entity;
        private bool _inExplosionProcess;

        public ExplosionState(Entity entity)
        {
            _entity = entity;
        }

        public override void Enter()
        {
            base.Enter();

            _entity.ShouldCastAbility.Value = true;
        }

        public void Update(float deltaTime)
        {
            if(_inExplosionProcess == false)
            {
                if (_entity.AbilityCastInProcess.Value)
                {
                    _inExplosionProcess = true;
                    _entity.ShouldCastAbility.Value = false;
                }
            }
            else
            {
                if(_entity.AbilityCastInProcess.Value == false)
                {
                    _entity.ShouldForceDeath.Value = true;
                    _entity.ShouldCastAbility.Value = false;
                }
            }
        }
    }
}