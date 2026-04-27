using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.Converters;
using UnityEngine;

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
            RegisterPresenters(container);
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

            container.RegisterAsSingle(CreateGameplayUIRoot);

            container.RegisterAsSingle(CreateGameplayPopupService);

            container.RegisterAsSingle(CreateMainHeroHolderService).NonLazy();
        }

        private static void RegisterFactories(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainHeroEntityFactory);
            container.RegisterAsSingle(CreateEnemiesEntityFactory);

            container.RegisterAsSingle(CreateBrainsFactory);

            container.RegisterAsSingle(CreateCombatEntityFactory);
            container.RegisterAsSingle(CreateAbilityFactory);

            container.RegisterAsSingle(CreateStagesFactory);
            container.RegisterAsSingle(CreateGameplayStatesFactory);

            container.RegisterAsSingle(CreateGameplayPresentersFactory);

            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();

            container.RegisterAsSingle(CreateUpgradesFactory);
        }

        private static void RegisterPresenters(DIContainer container)
        {
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
        }

        private static UpgradesFactory CreateUpgradesFactory(DIContainer container)
            => new(container, container.Resolve<EntitiesLifeContext>());

        private static GameplayPopupService CreateGameplayPopupService(DIContainer container)
        {
            return new(container.Resolve<ViewsFactory>(),
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<UIRoot>(),
                container.Resolve<GameplayPresentersFactory>());
        }

        private static AbilityFactory CreateAbilityFactory(DIContainer container)
            => new(
                container.Resolve<EntitiesLifeContext>(),
                container.Resolve<AbilityEffectsFactory>(),
                container.Resolve<WalletService>());

        private static UIRoot CreateGameplayUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            UIRoot prefab = resourcesAssetsLoader.Load<UIRoot>("UI/UIRoot");

            return Object.Instantiate(prefab);
        }

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer container)
        {
            UIRoot prefabUIRoot = container.Resolve<UIRoot>();

            GameplayScreenView view = container.Resolve<ViewsFactory>().Create<GameplayScreenView>(ViewIDs.GameplayScreen, prefabUIRoot.HUDLayer);

            GameplayScreenPresenter presenter = container.Resolve<GameplayPresentersFactory>().CreateGameplayScreenPresenter(view);

            return presenter;
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory(DIContainer container)
            => new(container, _inputArgs);

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

        private static AbilityEffectsFactory CreateCombatEntityFactory(DIContainer container) => new(container);

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