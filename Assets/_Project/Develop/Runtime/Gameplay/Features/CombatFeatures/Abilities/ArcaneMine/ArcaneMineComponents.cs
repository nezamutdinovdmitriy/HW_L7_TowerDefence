using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine
{
    public class ArcaneMineUseRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class CanUseArcaneMine : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}