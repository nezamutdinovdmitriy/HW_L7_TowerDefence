using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common
{
    public class TransfromComponent : IEntityComponent
    {
        public Transform Value;
    }

    public class CurrentTarget : IEntityComponent
    {
        public ReactiveVariable<Entity> Value;
    }
}