using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public sealed class AbilityCastInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public sealed class AbilityCastCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public sealed class AbilityCastSpawnEffectDelay : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public sealed class CanCastAbility : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public sealed class AbilityCastInProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public sealed class ShouldSpawnEffect : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public sealed class AbilitySlot : IEntityComponent
    {
        public ReactiveVariable<AbilitySlotType> Value;
    }

    public sealed class Ability : IEntityComponent
    {
        public ReactiveVariable<AbilityType> Value;
    }
}