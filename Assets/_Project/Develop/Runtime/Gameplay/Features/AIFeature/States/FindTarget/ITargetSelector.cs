using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature.States.FindTarget
{
    public interface ITargetSelector
    {
        public Entity SelectTargetFrom(IEnumerable<Entity> targets);
    }
}