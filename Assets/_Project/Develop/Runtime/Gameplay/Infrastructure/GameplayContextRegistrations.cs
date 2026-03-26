using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using Unity.VisualScripting.FullSerializer;

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
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateGameplayStatesContext);
        }

        private static void RegisterServices(DIContainer container)
        {
            container.RegisterAsSingle(CreateCollidersRegistryService);
            container.RegisterAsSingle<IGameplayInputService>(CreateDesktopInput);
            container.RegisterAsSingle(CreateScreenToWorldPositionConverter);
            container.RegisterAsSingle(CreateStageProvider);

            container.RegisterAsSingle(CreateMainHeroHolderService).NonLazy();
        }

        private static void RegisterFactories(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainHeroEntityFactory);
            container.RegisterAsSingle(CreateEnemiesEntityFactory);

            container.RegisterAsSingle(CreateBrainsFactory);

            container.RegisterAsSingle(CreateCombatEntityFactory);

            container.RegisterAsSingle(CreateStagesFactory);
            container.RegisterAsSingle(CreateGameplayStatesFactory);

            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
        }

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer container)
            => new(
                container.Resolve<GameplayStatesFactory>()
                .CreateGameplayStateMachine(
                    container.Resolve<ConfigsProvider>()
                    .GetConfig<LevelsListConfig>()
                    .GetConfigBy(_inputArgs.LevelNumber))
                );

        private static GameplayStatesFactory CreateGameplayStatesFactory(DIContainer container)
            => new(container);

        private static StageProvider CreateStageProvider(DIContainer container)
            => new(
                container.Resolve<ConfigsProvider>()
                    .GetConfig<LevelsListConfig>()
                    .GetConfigBy(_inputArgs.LevelNumber),
                container.Resolve<StagesFactory>()
                );

        private static StagesFactory CreateStagesFactory(DIContainer container)
            => new(container);

        private static BrainsFactory CreateBrainsFactory(DIContainer container)
            => new(container);

        private static AIBrainsContext CreateAIBrainsContext(DIContainer container)
            => new();

        private static MainHeroHolderService CreateMainHeroHolderService(DIContainer container)
            => new(container.Resolve<EntitiesLifeContext>());

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