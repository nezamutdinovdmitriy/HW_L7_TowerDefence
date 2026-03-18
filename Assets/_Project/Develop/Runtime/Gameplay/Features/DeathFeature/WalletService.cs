using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature
{
    public class WalletService
    {
        private readonly Dictionary<CurrencyType, ReactiveVariable<int>> _currencies;

        public WalletService(Dictionary<CurrencyType, ReactiveVariable<int>> currencies)
        {
            _currencies = new Dictionary<CurrencyType, ReactiveVariable<int>>(currencies);
        }

        public List<CurrencyType> AvailableCurrencies => _currencies.Keys.ToList();
        public IReadOnlyVariable<int> GetCurrency(CurrencyType type) => _currencies[type];

        public bool Enough(CurrencyType type, int amount)
        {
            ValidateAmount(amount);

            return _currencies[type].Value >= amount;
        }

        public void Add(CurrencyType type, int amount)
        {
            ValidateAmount(amount);

            _currencies[type].Value += amount;
        }

        public void Spend(CurrencyType type, int amount)
        {
            if(Enough(type, amount) == false)
                throw new InvalidOperationException("Not enough: " + type.ToString());

            ValidateAmount(amount);

            _currencies[type].Value -= amount;
        }

        private void ValidateAmount(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
        }
    }
}