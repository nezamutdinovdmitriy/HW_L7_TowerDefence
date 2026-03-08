using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public sealed class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        private readonly CollidersRegistryService _collidersRegistryService;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateTower(Vector3 position)
        {
            Entity entity = CreateEmpty();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/Tower");

            entity
                .AddMaxHealth(new ReactiveVariable<float>(10))
                .AddCurrentHealth(new ReactiveVariable<float>(10))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(500))
                .AddIsDead()
                .AddInDeathProcess();

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition canRotateToMousePosition = new CompositeCondition()
                .Add(new FuncCondition(() => true));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanRotate(canRotateToMousePosition);

            entity
                .AddSystem(new MouseRotationDirectionUpdateSystem(
                    _container.Resolve<ScreenToWorldPositionConverter>(),
                    _container.Resolve<IGameplayInputService>()))
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateBaseСreep(Vector3 position)
        {
            Entity entity = CreateEmpty();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/Enemy");

            entity
                .AddInputMovementDirection()
                .AddMovementDirection()
                .AddMovementSpeed(new ReactiveVariable<float>(10))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(800));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => true));

            ICompositeCondition canRotateToMousePosition = new CompositeCondition()
                .Add(new FuncCondition(() => true));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotateToMousePosition);

            entity
                .AddSystem(new PlayerInputMovementSystem(_container.Resolve<IGameplayInputService>()))
                .AddSystem(new MovementDirectionResolveSystem())
                .AddSystem(new TransformMovementAppliedSystem())
                .AddSystem(new MovementRotationDirectionUpdateSystem())
                .AddSystem(new TransformRotationAppliedSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new();
    }
}