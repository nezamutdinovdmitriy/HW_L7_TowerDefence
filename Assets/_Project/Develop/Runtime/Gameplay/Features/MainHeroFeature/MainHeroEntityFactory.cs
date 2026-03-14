using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature
{
    public sealed class MainHeroEntityFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        private readonly CollidersRegistryService _collidersRegistryService;

        public MainHeroEntityFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateTower(Vector3 position)
        {
            Entity entity = new();
            MonoEntity monoEntity = _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/Tower");

            entity
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(500))
                .AddIsDead()
                .AddInDeathProcess()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent();

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canRotateToMousePosition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanRotate(canRotateToMousePosition)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new MouseRotationDirectionUpdateSystem(
                    _container.Resolve<ScreenToWorldPositionConverter>(),
                    _container.Resolve<IGameplayInputService>()))
                .AddSystem(new TransformRotationAppliedSystem())
                .AddSystem(new AttackSystem(
                    _container.Resolve<CombatEntityFactory>(),
                    _container.Resolve<IGameplayInputService>(),
                    _container.Resolve<ScreenToWorldPositionConverter>()))
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}