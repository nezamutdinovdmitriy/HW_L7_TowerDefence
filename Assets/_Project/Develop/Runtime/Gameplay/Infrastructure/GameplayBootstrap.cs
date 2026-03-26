using Assets._Project.Develop.Runtime.Gameplay.Configs.Entities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public sealed class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;

        private AIBrainsContext _brainsContext;
        private EntitiesLifeContext _entitiesLifeContext;
        private GameplayStatesContext _gameplayStatesContext;

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация геймплейной сцены");

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            _container.Resolve<MainHeroEntityFactory>().CreateTower(
                _container.Resolve<ConfigsProvider>().GetConfig<BaseTowerConfig>(),
                _container.Resolve<ConfigsProvider>().GetConfig<LevelsListConfig>().GetConfigBy(_inputArgs.LevelNumber));

            yield break;
        }

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override void Run()
        {
            Debug.Log("Старт геймплейной сцены");

            _gameplayStatesContext.Run();
        }

        private void Update()
        {
            _entitiesLifeContext?.Update(Time.deltaTime);
            _brainsContext?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);
        }

        private void FixedUpdate() => _entitiesLifeContext?.FixedUpdate(Time.fixedDeltaTime);
    }
}