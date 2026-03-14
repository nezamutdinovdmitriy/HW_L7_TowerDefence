using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.Converters;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public sealed class GameplayContextRegistrations
    {
        private static GameplayInputArgs _inputArgs;

        public static void Process(DIContainer container, GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;

            RegisterContexts(container);
            RegisterServices(container);
            RegisterFactories(container);
        }

        private static void RegisterContexts(DIContainer container)
        {
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateMonoEntitiesLifeContext);
        }

        private static void RegisterServices(DIContainer container)
        {
            container.RegisterAsSingle(CreateCollidersRegistryService);
            container.RegisterAsSingle<IGameplayInputService>(CreateDesktopInput);
            container.RegisterAsSingle(CreateScreenToWorldPositionConverter);
        }

        private static void RegisterFactories(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainHeroEntityFactory);
            container.RegisterAsSingle(CreateEnemiesEntityFactory);

            container.RegisterAsSingle(CreateCombatEntityFactory);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
        }

        private static CombatEntityFactory CreateCombatEntityFactory(DIContainer container) => new(container);

        private static ScreenToWorldPositionConverter CreateScreenToWorldPositionConverter(DIContainer container)
            => new(
                UnityEngine.Camera.main,
                UnityLayersAPI.LayerMaskEnvironment
                );

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer container)
            => new(
                container.Resolve<ResourcesAssetsLoader>(),
                container.Resolve<MonoEntitiesLifeContext>(),
                container.Resolve<CollidersRegistryService>()
                );

        private static DesktopGameplayInput CreateDesktopInput(DIContainer container) => new();

        private static MainHeroEntityFactory CreateMainHeroEntityFactory(DIContainer container) => new(container);
        private static EnemiesEntityFactory CreateEnemiesEntityFactory(DIContainer container) => new(container);

        private static MonoEntitiesLifeContext CreateMonoEntitiesLifeContext(DIContainer container)
            => new(container.Resolve<EntitiesLifeContext>());

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer container) => new();

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer container) => new();
    }
}