using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class BodyCollider : IEntityComponent
    {
        public CapsuleCollider Value;
    }

    public class ContactsCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class ContactsEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }

    public class ContactsDetectingMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class IsTouchDeathMask : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class IsTouchAnotherTeam : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class DeathMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class CanStartDetecting : IEntityComponent
    {
        public ICompositeCondition Value;
    }
    
    public class AreaContactDetectingRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}