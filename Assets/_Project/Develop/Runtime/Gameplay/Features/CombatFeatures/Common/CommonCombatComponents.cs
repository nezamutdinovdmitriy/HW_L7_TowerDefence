using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public sealed class StartAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public sealed class ShootPoint : IEntityComponent
    {
        public Transform Value;
    }

    public sealed class AbilityStorage : IEntityComponent
    {
        public Dictionary<AbilityType, ReactiveEvent> Value;
    }

    public sealed class AbilityCurrent : IEntityComponent
    {
        public ReactiveVariable<AbilityType> Value;
    }

    public sealed class AimPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }
}