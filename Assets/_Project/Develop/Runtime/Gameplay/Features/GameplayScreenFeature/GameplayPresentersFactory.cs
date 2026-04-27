using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesPanelFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.GameplayScreenFeature
{
    public class GameplayPresentersFactory
    {
        private DIContainer _container;
        private GameplayInputArgs _gameplayInputArgs;

        public GameplayPresentersFactory(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public AbilityPanelPresenter CreateAbilityPanelPresenter(AbilityPaneltView view)
            => new(
                _container.Resolve<MainHeroHolderService>(),
                view,
                _container.Resolve<ViewsFactory>(),
                this);

        public AbilitySelectButtonPresenter CreateAbilitySelectButtonPresenter(AbilitySelectButtonView view, Entity ability)
            => new(
                view,
                _container.Resolve<MainHeroHolderService>(), 
                ability);

        public EntityHealthPresenter CreateEntityHealthPresenter(Entity entity, BarWithText view)
            => new(view, entity);

        public EntitiesHealthDisplayPresenter CreateEntitiesHealthDisplayPresenter(EntitiesHealthDisplay view)
            => new(
                view,
                _container.Resolve<EntitiesLifeContext>(),
                this,
                _container.Resolve<ViewsFactory>());

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new(view, _container.Resolve<GameplayPresentersFactory>(), _container.Resolve<ProjectPresentersFactory>());

        public StagePresenter CreateStagePresenter(IconTextView view)
            => new(view, _container.Resolve<StageProvider>());

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView view)
            => new(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView view)
            => new(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _gameplayInputArgs);
    }
}