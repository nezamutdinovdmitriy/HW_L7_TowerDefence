using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
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
                .AddRotationSpeed()
                .AddIsDead()
                .AddInDeathProcess();

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            entity.AddMustDie(mustDie);


            entity
                .AddSystem(new RotationDirectionUpdateSystem(
                    new MouseRotationDirectionProvider(
                        _container.Resolve<ScreenToWorldPositionConverter>(),
                        entity.Transfrom,
                        _container.Resolve<IGameplayInputService>())))
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);
            
            return entity;
        }

        private Entity CreateEmpty() => new();
    }
}