using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion
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

    public class ExplosionLifetime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ExplosionRequested : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}