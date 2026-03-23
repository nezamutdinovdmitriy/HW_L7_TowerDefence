using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat
{
    public class ExplosionState : State, IUpdatableState
    {
        private readonly CombatEntityFactory _combatEntityFactory;
        private readonly Entity _entity;

        public ExplosionState(Entity entity, CombatEntityFactory combatEntityFactory)
        {
            _entity = entity;
            _combatEntityFactory = combatEntityFactory;
        }

        public override void Enter()
        {
            base.Enter();

            _combatEntityFactory.CreateExplosion(_entity.Transfrom.position, _entity.ExplosionRadius.Value, _entity);
            _entity.ShouldForceDeath.Value = true;
        }

        public void Update(float deltaTime)
        {
        }
    }
}