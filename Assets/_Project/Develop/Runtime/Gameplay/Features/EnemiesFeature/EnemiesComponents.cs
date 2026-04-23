using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature
{
    public class AttackRange : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}