using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public interface IRotationDirectionProvider
    {
        public Vector3 GetRotationDirection();
    }
}