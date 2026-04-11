using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public sealed class StartAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public sealed class AbilityUseRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public sealed class AbilityFireballConfig : IEntityComponent
    {
        public FireballAbilityConfig Value;
    }

    public sealed class AbilityExplosionConfig : IEntityComponent
    {
        public ExplosionAbilityConfig Value;
    }

    public sealed class AbilityArcaneMineConfig : IEntityComponent
    {
        public ArcaneMineAbilityConfig Value;
    }

    public sealed class AbilityStartedEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public sealed class AbilityEndedEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public sealed class AbilityCanUse : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public sealed class ShootPoint : IEntityComponent
    {
        public Transform Value;
    }

    public sealed class AbilityStorage : IEntityComponent
    {
        public Dictionary<AbilitySlotType, Entity> Value;
    }

    public sealed class AbilityCurrent : IEntityComponent
    {
        public ReactiveVariable<AbilitySlotType> Value;
    }

    public sealed class AimPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }
}