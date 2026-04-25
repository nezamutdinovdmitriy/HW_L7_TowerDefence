using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle
{
    public class ToxicPuddleDamagePerTick : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ToxicPuddleCooldownTick : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ToxicPuddleRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}