using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage
{
    public class ContactDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}