using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.Registrators
{
    public sealed class BodyTransformEntityRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _bodyTransform;
        public override void Register(Entity entity)
        {
            entity.AddBodyTransform(_bodyTransform);
        }
    }
}