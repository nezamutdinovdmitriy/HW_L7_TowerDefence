using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
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

    public sealed class ShouldStartProcess : IEntityComponent
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

    public sealed class AbilityAnimatorKey : IEntityComponent
    {
        public string Value;
    }

    public sealed class AbilityCost : IEntityComponent
    {
        public int Value;
    }

    public sealed class CurrencyCost : IEntityComponent
    {
        public CurrencyType Value;
    }

    public sealed class ShouldSpendCost : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public sealed class AbilityCastKeyMapping : IEntityComponent
    {
        public AbilityToAnimatorKeyMapping Value;
    }

    public sealed class CurrentCastingAbility : IEntityComponent
    {
        public ReactiveVariable<Entity> Value; 
    }
}