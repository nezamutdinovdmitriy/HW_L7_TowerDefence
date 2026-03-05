using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class DesktopGameplayInput : IGameplayInputService
    {
        private const KeyCode ShootKey = KeyCode.Mouse0;

        public bool IsEnabled { get ; set ; } = true;

        public Vector3? Aiming => Input.mousePosition;

        public bool IsShooting
        {
            get
            {
                if(IsEnabled == false)
                    return false;

                return Input.GetKeyDown(ShootKey);
            }
        }
    }
}