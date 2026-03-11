using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.Registrators
{
    public class BodyColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Collider _collider;

        public override void Register(Entity entity)
        {

        }
    }
}