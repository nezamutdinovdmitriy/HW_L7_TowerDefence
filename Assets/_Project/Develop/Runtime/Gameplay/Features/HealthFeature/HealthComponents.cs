using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public class MaxHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CurrentHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}