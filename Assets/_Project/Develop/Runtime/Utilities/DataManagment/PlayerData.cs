using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment
{
    public sealed class PlayerData : ISaveData
    {
        public Dictionary<CurrencyType, int> WalletData;
        public HashSet<UpgradeType> Upgrades;
    }
}
