using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball
{
    public class FireballUseRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class CanUseFireball : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}