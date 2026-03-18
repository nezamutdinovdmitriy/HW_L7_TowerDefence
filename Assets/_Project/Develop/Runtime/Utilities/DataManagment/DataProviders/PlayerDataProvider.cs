using Assets._Project.Develop.Runtime.Meta.Configs.Wallet;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders
{
    public sealed class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProvider _configsProvider;

        public PlayerDataProvider(
            ISaveLoadSerivce saveLoadSerivce,
            ConfigsProvider configsProviderService) : base(saveLoadSerivce)
        {
            _configsProvider = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
            };
        }

        private Dictionary<CurrencyType, int> InitWalletData()
        {
            Dictionary<CurrencyType, int> walletData = new();

            StartWalletConfig walletConfig = _configsProvider.GetConfig<StartWalletConfig>();

            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                walletData[currencyType] = walletConfig.GetValueFor(currencyType);

            return walletData;
        }
    }
}
