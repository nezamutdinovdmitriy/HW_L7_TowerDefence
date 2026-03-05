using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.Registrators
{
    public class TransformEntityRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _transform;

        public override void Register(Entity entity) => entity.AddTransfrom(_transform);
    }
}