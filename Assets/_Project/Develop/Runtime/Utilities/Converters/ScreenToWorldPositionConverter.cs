using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Converters
{
    public class ScreenToWorldPositionConverter
    {
        private Camera _camera;
        private LayerMask _layerMask;

        public ScreenToWorldPositionConverter(Camera camera, LayerMask layerMask)
        {
            _camera = camera;
            _layerMask = layerMask;
        }

        public Vector3 GetPosition(Vector3 screenPosition, float targetY)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);

            float distance = (targetY - ray.origin.y) / ray.direction.y;

            return ray.origin + ray.direction * distance;
        }
    }
}