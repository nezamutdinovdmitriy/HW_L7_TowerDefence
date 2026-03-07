using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public sealed class DesktopGameplayInput : IGameplayInputService
    {
        private const KeyCode ShootKey = KeyCode.Mouse0;
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        public bool IsEnabled { get; set; } = true;

        public Vector3? Aiming => Input.mousePosition;

        public bool IsShooting
        {
            get
            {
                if (IsEnabled == false)
                    return false;

                return Input.GetKeyDown(ShootKey);
            }
        }

        public Vector3 MovementDirection
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
            }
        }
    }
}