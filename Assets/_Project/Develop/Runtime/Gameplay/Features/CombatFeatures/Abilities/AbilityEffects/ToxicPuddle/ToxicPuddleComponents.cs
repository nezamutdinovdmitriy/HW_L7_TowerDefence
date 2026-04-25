using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle
{
    public class ToxicPuddleRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}