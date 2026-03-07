using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class MovementDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MovementSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class IsMoving : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class CanMove : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}