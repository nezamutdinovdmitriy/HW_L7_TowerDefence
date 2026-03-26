using Assets._Project.Develop.Runtime.Gameplay.Configs.Entities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Meta.Configs.Wallet;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesConfigsLoader : IConfigsLoader
{
    private readonly ResourcesAssetsLoader _resources;

    private readonly Dictionary<Type, string> _configsResoucesPaths = new()
    {
        {typeof(StartWalletConfig), "Meta/Configs/StartWalletConfig" },
        {typeof(LevelsListConfig), "Gameplay/Configs/Levels/LevelsListConfig" },
        {typeof(BaseTowerConfig), "Gameplay/Configs/Entities/BaseTowerConfig" },
    };

    public ResourcesConfigsLoader(ResourcesAssetsLoader resources) => _resources = resources;

    public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
    {
        Dictionary<Type, object> loadedConfigs = new();

        foreach(KeyValuePair<Type, string> configResourcesPath in _configsResoucesPaths)
        {
            ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);
            loadedConfigs.Add(configResourcesPath.Key, config);
            yield return null;
        }

        onConfigsLoaded?.Invoke(loadedConfigs);
    }
}
