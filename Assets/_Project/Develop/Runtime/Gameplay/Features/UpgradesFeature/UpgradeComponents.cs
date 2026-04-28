using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature
{
    public class Upgrades : IEntityComponent
    {
        public List<Entity> Value;
    }

    public class TowerHealOnWaveStartUpgradeTag : IEntityComponent
    {
    }

    public class DamageFirstEnemiesUpgradeTag : IEntityComponent
    {
    }

    public class FireballDamageMultiplierUpgradeTag : IEntityComponent
    {
    }

    public class CanApplyEffect : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class CanFinalizeEffect : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class IsEffectApplied : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class Percent : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class Multiplier : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}