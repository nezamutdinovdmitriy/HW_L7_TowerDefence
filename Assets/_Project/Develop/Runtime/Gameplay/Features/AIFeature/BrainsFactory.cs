using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Movement;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature
{
    public sealed class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly AIBrainsContext _brainsContext;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;

            _brainsContext = container.Resolve<AIBrainsContext>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreateBaseEnemyBrain(Entity entity, ITargetSelector targetSelector)
        {
            //FindTargetState findTargetState = new(targetSelector, _entitiesLifeContext, entity);
            MoveToTargetState moveToTargetState = new(entity);

            ICompositeCondition findTargetToMoveToTarget = new CompositeCondition()
                .Add(new FuncCondition(() => true));

            ICompositeCondition moveToTargetToFindTarget = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentTarget.Value == null));

            AIStateMachine behaviour = new();

            //behaviour.AddState(findTargetState);
            behaviour.AddState(moveToTargetState);

            //behaviour.AddTransition(findTargetState, moveToTargetState, findTargetToMoveToTarget);
            //behaviour.AddTransition(moveToTargetState, findTargetState, moveToTargetToFindTarget);

            StateMachineBrain brain = new(behaviour);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }
    }
}