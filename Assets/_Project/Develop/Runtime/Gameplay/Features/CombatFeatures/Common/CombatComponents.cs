using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public sealed class ShootPoint : IEntityComponent
    {
        public Transform Value;
    }

    public sealed class InputAimPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public sealed class TargetAimPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public sealed class AbilitiesEquipped : IEntityComponent
    {
        public Dictionary<AbilitySlotType, Entity> Value;
    }

    public sealed class AbilitiesStorage : IEntityComponent
    {
        public Dictionary<AbilitySlotType, List<Entity>> Value;
    }

    public sealed class AbilitySlotCurrent : IEntityComponent
    {
        public ReactiveVariable<AbilitySlotType> Value;
    }

    public sealed class ShouldCastAbility : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}