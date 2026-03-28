using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.Meta.Features.MainMenuFeature
{
    public sealed class StartGameButtonPresenter : IPresenter
    {
        private readonly Button _startGameButton;

        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly LevelsListConfig _levelsListConfig;

        public StartGameButtonPresenter(
            Button startGameButton, 
            SceneSwitcherService sceneSwitcherService, 
            ICoroutinesPerformer coroutinesPerformer, 
            LevelsListConfig levelsListConfig)
        {
            _startGameButton = startGameButton;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _levelsListConfig = levelsListConfig;
        }

        public void Initialize() => _startGameButton.onClick.AddListener(OnClicked);

        public void Dispose() => _startGameButton.onClick.RemoveListener(OnClicked);

        private void OnClicked()
        {
            int randomLevel = Random.Range(1, _levelsListConfig.Levels.Count + 1);
            
            Debug.Log("Рандомный уровень: " + randomLevel);
            Debug.Log("Всего уровней: " + _levelsListConfig.Levels.Count);

            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(randomLevel)));
        }
    }
}