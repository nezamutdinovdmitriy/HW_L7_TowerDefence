using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Converters
{
    public sealed class ScreenToWorldPositionConverter
    {
        private readonly Camera _camera;
        private readonly LayerMask _layerMask;
        private readonly float _maxDistance = 100f;

        public ScreenToWorldPositionConverter(Camera camera, LayerMask layerMask)
        {
            _camera = camera;
            _layerMask = layerMask;
        }

        public Vector3 GetPosition(Vector3 screenPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
                return hit.point;

            return Vector3.zero;
        }
    }
}