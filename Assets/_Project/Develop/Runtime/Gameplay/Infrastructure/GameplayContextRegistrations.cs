using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public sealed class GameplayContextRegistrations
    {
        private static GameplayInputArgs _inputArgs;

        public static void Process(DIContainer container, GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;

            container.RegisterAsSingle(CreateCollidersRegistryService);
        }

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer container) => new();
    }
}