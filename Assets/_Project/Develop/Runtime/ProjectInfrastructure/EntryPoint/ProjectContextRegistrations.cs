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
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.ProjectInfrastructure.EntryPoint
{
    public sealed class ProjectContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);

            container.RegisterAsSingle(CreateTimerServiceFactory);

            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);

            container.RegisterAsSingle(CreateConfigsProvider);
            container.RegisterAsSingle(CreatePlayerDataProvider);

            container.RegisterAsSingle(CreateResourcesAssetsLoader);
            container.RegisterAsSingle<ISaveLoadSerivce>(CreateSaveLoadService);
        }

        private static SaveLoadService CreateSaveLoadService(DIContainer c)
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