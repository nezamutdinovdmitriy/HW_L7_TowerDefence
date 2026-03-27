using Assets._Project.Develop.Runtime.Meta.Configs.Wallet;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.UI
{
    public sealed class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public CurrencyPresenter CreateCurrencyPresenter(
            IconTextView view, IReadOnlyVariable<int> currency, CurrencyType currencyType)
            => new(
                currency,
                currencyType,
                _container.Resolve<ConfigsProvider>().GetConfig<CurrencyIconsConfig>(),
                view);

        public WalletPresenter CreateWalletPresenter(IconTextListView view)
            => new(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);
    }
}