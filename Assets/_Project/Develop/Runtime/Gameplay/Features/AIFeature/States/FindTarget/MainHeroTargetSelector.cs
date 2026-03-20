using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget
{
    public sealed class MainHeroTargetSelector : ITargetSelector
    {
        private readonly MainHeroHolderService _mainHeroHolderService;

        public MainHeroTargetSelector(MainHeroHolderService mainHeroHolderService)
        {
            _mainHeroHolderService = mainHeroHolderService;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets) => _mainHeroHolderService.MainHero;
    }
}