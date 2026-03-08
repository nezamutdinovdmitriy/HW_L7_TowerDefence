using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class InputMovementDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }
}