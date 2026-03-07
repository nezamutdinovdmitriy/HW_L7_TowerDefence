using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public interface IGameplayInputService
    {
        public bool IsEnabled { get; set; }
        
        public Vector3? Aiming { get; }
        public bool IsShooting { get; }

        public Vector3 MovementDirection { get; }
    }
}