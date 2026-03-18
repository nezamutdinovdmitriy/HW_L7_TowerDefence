using Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataRepository;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.KeysStorage;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.Serializers;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.ProjectInfrastructure.EntryPoint
{
    public sealed class ProjectContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            RegisterServices(container);
            RegisterFactories(container);
        }

        private static void RegisterServices(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
            container.RegisterAsSingle<ISaveLoadSerivce>(CreateSaveLoadService);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle(CreateResourcesAssetsLoader);
            container.RegisterAsSingle(CreateConfigsProvider);
            container.RegisterAsSingle(CreatePlayerDataProvider);

            container.RegisterAsSingle(CreateWalletService).NonLazy();
        }

        private static void RegisterFactories(DIContainer container)
        {
            container.RegisterAsSingle(CreateTimerServiceFactory);
        }

        private static WalletService CreateWalletService(DIContainer container)
        {
            Dictionary<CurrencyType, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                currencies[currencyType] = new ReactiveVariable<int>();

            return new WalletService(currencies);
        }

        private static SaveLoadService CreateSaveLoadService(DIContainer container)
        {
            IDataSerializer dataSerializer = new JsonSerializer();
            IDataKeysStorage dataKeysStorage = new MapDataKeysStorage();

            string saveFolderPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath;

            IDataRepository dataRepository = new LocalFileDataRepository(saveFolderPath, "json");

            return new SaveLoadService(dataSerializer, dataKeysStorage, dataRepository);
        }

        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer c)
            => new(
                c.Resolve<ISaveLoadSerivce>(),
                c.Resolve<ConfigsProvider>());

        private static TimerServiceFactory CreateTimerServiceFactory(DIContainer container)
            => new(container);

        private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            CoroutinesPerformer coroutinesPerformerPrefab = resourcesAssetsLoader
                .Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }

        private static LoadingScreen CreateLoadingScreen(DIContainer container)
            => Object.Instantiate(container
                .Resolve<ResourcesAssetsLoader>()
                .Load<LoadingScreen>(("Utilities/StandardLoadingScreen")));

        private static SceneLoaderService CreateSceneLoaderService(DIContainer container)
            => new();

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer container)
            => new(
                container.Resolve<SceneLoaderService>(),
                container.Resolve<ILoadingScreen>(),
                container);

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer container)
            => new();

        private static ConfigsProvider CreateConfigsProvider(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();
            ResourcesConfigsLoader resourcesConfigsLoader = new(resourcesAssetsLoader);

            return new(resourcesConfigsLoader);
        }
    }
}