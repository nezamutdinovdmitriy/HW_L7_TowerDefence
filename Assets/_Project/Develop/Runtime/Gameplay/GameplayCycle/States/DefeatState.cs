using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class DefeatState : EndGameState, IUpdatableState
    {
        private readonly GameplayPopupService _popupService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public DefeatState(
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            IGameplayInputService inputService,
            GameplayPopupService popupService) : base(inputService)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Defeat");

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _popupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}