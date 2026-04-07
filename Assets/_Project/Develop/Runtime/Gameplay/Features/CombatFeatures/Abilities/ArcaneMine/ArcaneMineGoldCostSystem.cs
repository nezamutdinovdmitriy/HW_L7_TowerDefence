using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public sealed class ArcaneMineGoldCostSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly WalletService _walletService;
        private readonly CurrencyType _currencyType;

        private ReactiveEvent _arcaneMineUseEvent;
        private ReactiveVariable<int> _cost;

        private IDisposable _disposable;

        public ArcaneMineGoldCostSystem(CurrencyType currency, WalletService walletService)
        {
            _walletService = walletService;
            _currencyType = currency;
        }

        public void OnInitialize(Entity entity)
        {
            _cost = entity.ArcaneMineCost;
            _arcaneMineUseEvent = entity.AbilityStartedEvent;

            _disposable = _arcaneMineUseEvent.Subscribe(OnArcaneMineUsed);
        }

        public void OnDispose() => _disposable.Dispose();

        private void OnArcaneMineUsed() => _walletService.Spend(_currencyType, _cost.Value);
    }
}