using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Configs.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/NewCurrencyIconsConfig", fileName = "CurrencyIconsConfig")]
    public sealed class CurrencyIconsConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyConfig> _configs;

        public Sprite GetSpriteFor(CurrencyType currencyType) => _configs.First(config => config.Type == currencyType).Sprite;

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrencyType Type { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
        }
    }
}