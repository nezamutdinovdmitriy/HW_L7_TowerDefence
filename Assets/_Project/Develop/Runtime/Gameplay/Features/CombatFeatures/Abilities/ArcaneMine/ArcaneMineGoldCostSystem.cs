using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public class ArcaneMineGoldCostSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly WalletService _walletService;

        private ReactiveEvent _arcaneMineUseEvent;
        private ReactiveVariable<int> _cost;

        private IDisposable _disposable;

        public ArcaneMineGoldCostSystem(WalletService walletService) => _walletService = walletService;

        public void OnInitialize(Entity entity)
        {
            _cost = entity.ArcaneMineCost;
            _arcaneMineUseEvent = entity.ArcaneMineUseEvent;

            _disposable = _arcaneMineUseEvent.Subscribe(OnArcaneMineUsed);
        }

        public void OnDispose() => _disposable.Dispose();

        private void OnArcaneMineUsed() => _walletService.Spend(CurrencyType.Gold, _cost.Value);
    }
}