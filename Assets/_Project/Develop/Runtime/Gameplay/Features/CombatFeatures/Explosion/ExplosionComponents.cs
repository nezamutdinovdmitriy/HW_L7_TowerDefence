using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Explosion
{
    public class ExplosionRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }   

    public class ExplosionDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanSpawnExplosion : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class ExplosionInProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class ExplosionDestroyDelay : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}