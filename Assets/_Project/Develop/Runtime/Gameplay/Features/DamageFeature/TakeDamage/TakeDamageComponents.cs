using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage
{
    public class ContactDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CooldownTick : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class DamageTick : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}