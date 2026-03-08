using Assets._Project.Develop.Runtime.Utilities.Reactive;
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
}