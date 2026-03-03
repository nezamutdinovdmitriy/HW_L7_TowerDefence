using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders
{
    public sealed class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProvider _configsProviderService;

        public PlayerDataProvider(
            ISaveLoadSerivce saveLoadSerivce,
            ConfigsProvider configsProviderService) : base(saveLoadSerivce)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                //WalletData = InitWalletData(),
                //CompletedLevels = new()
            };
        }

        //private Dictionary<CurrencyTypes, int> InitWalletData()
        //{
        //    Dictionary<CurrencyTypes, int> walletData = new();

        //    StartWalletConfig walletConfig = _configsProviderService.GetConfig<StartWalletConfig>();

        //    foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
        //        walletData[currencyType] = walletConfig.GetValueFor(currencyType);

        //    return walletData;
        //}
    }
}
