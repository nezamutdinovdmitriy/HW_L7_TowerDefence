using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Combat;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.Movement;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

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

        public StateMachineBrain CreateRuneTotemBrain(Entity entity, ITargetSelector targetSelector)
        {
            RotateToTargetState rotateToTargetState = new(entity);

            AttackState attackState = new(entity);

            ICondition canCastAbility = entity.CanCastAbility;
            Transform transform = entity.Transfrom;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canCastAbility)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transfrom.position - transform.position));
                    return angleToTarget < 3f;
                }));

            ReactiveVariable<bool> inCastProcess = entity.AbilityCastInProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inCastProcess.Value == false);

            AIStateMachine combatState = new();

            combatState.AddState(rotateToTargetState);
            combatState.AddState(attackState);

            combatState.AddTransition(rotateToTargetState, attackState, fromRotateToAttackCondition);
            combatState.AddTransition(attackState, rotateToTargetState, fromAttackToRotateStateCondition);

            FindTargetState findTargetState = new(targetSelector, _entitiesLifeContext, entity);

            AIParallelState parallelState = new(findTargetState, combatState);
            
            AIStateMachine rootStateMachine = new();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateRangeEnemyBrain(Entity entity, ITargetSelector targetSelector)
        {
            FindTargetState findTargetState = new(targetSelector, _entitiesLifeContext, entity);
            MoveToTargetState moveToTargetState = new(entity);
            AttackState attackState = new(entity);

            AIStateMachine movementState = new();

            ICompositeCondition findTargetToMoveToTarget = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentTarget.Value != null));

            ICompositeCondition moveToTargetToFindTarget = new CompositeCondition(LogicOperation.Or)
               .Add(new FuncCondition(() => entity.CurrentTarget.Value == null))
               .Add(new FuncCondition(() => entity.CurrentTarget.Value.IsDead.Value));

            movementState.AddState(findTargetState);
            movementState.AddState(moveToTargetState);

            movementState.AddTransition(findTargetState, moveToTargetState, findTargetToMoveToTarget);
            movementState.AddTransition(moveToTargetState, findTargetState, moveToTargetToFindTarget);

            AIStateMachine combatState = new();

            combatState.AddState(attackState);

            AIStateMachine behaviour = new();

            ICompositeCondition movementToCombat = new CompositeCondition()
               .Add(new FuncCondition(() =>
               {
                   if (entity.CurrentTarget.Value != null)
                   {
                       Vector3 targetPosition = entity.CurrentTarget.Value.Transfrom.position;
                       targetPosition.y = 0;

                       float threshold = entity.AttackRange.Value;

                       float sqrDistance = (entity.Transfrom.position - targetPosition).sqrMagnitude;
                       float sqrThreshold = threshold * threshold;

                       if (sqrDistance <= sqrThreshold)
                           return true;
                   }

                   return false;
               }));

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, movementToCombat);

            StateMachineBrain brain = new(behaviour);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateBaseEnemyBrain(Entity entity, ITargetSelector targetSelector)
        {
            FindTargetState findTargetState = new(targetSelector, _entitiesLifeContext, entity);
            MoveToTargetState moveToTargetState = new(entity);
            ExplosionState explosionState = new(entity);

            AIStateMachine movementState = new();

            ICompositeCondition findTargetToMoveToTarget = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentTarget.Value != null));

            ICompositeCondition moveToTargetToFindTarget = new CompositeCondition(LogicOperation.Or)
               .Add(new FuncCondition(() => entity.CurrentTarget.Value == null))
               .Add(new FuncCondition(() => entity.CurrentTarget.Value.IsDead.Value));

            movementState.AddState(findTargetState);
            movementState.AddState(moveToTargetState);

            movementState.AddTransition(findTargetState, moveToTargetState, findTargetToMoveToTarget);
            movementState.AddTransition(moveToTargetState, findTargetState, moveToTargetToFindTarget);

            AIStateMachine combatState = new();

            combatState.AddState(explosionState);

            AIStateMachine behaviour = new();

            ICompositeCondition movementToCombat = new CompositeCondition()
               .Add(new FuncCondition(() =>
               {
                   if (entity.CurrentTarget.Value != null)
                   {
                       Vector3 targetPosition = entity.CurrentTarget.Value.Transfrom.position;
                       targetPosition.y = 0;

                       float threshold = entity.AbilityStorage[AbilitySlotType.Main].ExplosionRadius.Value;

                       float sqrDistance = (entity.Transfrom.position - targetPosition).sqrMagnitude;
                       float sqrThreshold = threshold * threshold;

                       if (sqrDistance <= sqrThreshold)
                           return true;
                   }

                   return false;
               }));

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, movementToCombat);

            StateMachineBrain brain = new(behaviour);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }
    }
}