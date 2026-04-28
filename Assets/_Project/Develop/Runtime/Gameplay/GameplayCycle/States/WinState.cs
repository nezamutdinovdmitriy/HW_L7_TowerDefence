using Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public sealed class WinState : EndGameState, IUpdatableState
    {
        private readonly GameplayPopupService _popupService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly WalletService _walletService;
        private readonly int _victoryReward;

        public WinState(
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            IGameplayInputService inputService,
            WalletService walletService,
            int victoryReward,
            GameplayPopupService popupService) : base(inputService)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _walletService = walletService;
            _victoryReward = victoryReward;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log($"Win\nReward: {_victoryReward}");

            _walletService.Add(CurrencyType.Gold, _victoryReward);
            _walletService.Add(CurrencyType.Gem, _victoryReward / 2);

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _popupService.OpenWinPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}