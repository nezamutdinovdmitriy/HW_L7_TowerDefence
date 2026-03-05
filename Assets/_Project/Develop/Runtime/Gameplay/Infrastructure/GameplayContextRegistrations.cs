using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;

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
        }

        private static void RegisterFactories(DIContainer container)
        {
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
        }

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer container) => new(
                container.Resolve<ResourcesAssetsLoader>(),
                container.Resolve<MonoEntitiesLifeContext>(),
                container.Resolve<CollidersRegistryService>());

        private static EntitiesFactory CreateEntitiesFactory(DIContainer container) => new(container);

        private static MonoEntitiesLifeContext CreateMonoEntitiesLifeContext(DIContainer container) => new(container.Resolve<EntitiesLifeContext>());

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer container) => new();

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer container) => new();
    }
}