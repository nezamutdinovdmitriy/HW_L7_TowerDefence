using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Converters
{
    public sealed class ScreenToWorldPositionConverter
    {
        private readonly Camera _camera;
        private readonly LayerMask _layerMask;
        private readonly float _maxDistance = 100f;

        private Vector3 _lastValidPosition;

        public ScreenToWorldPositionConverter(Camera camera, LayerMask layerMask)
        {
            _camera = camera;
            _layerMask = layerMask;
        }

        public bool TryGetPosition(Vector3 screenPosition, out Vector3 worldPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
            {
                worldPosition = hit.point;
                return true;
            }

            worldPosition = default;
            return false;
        }

        public Vector3 GetPosition(Vector3 screenPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
            {
                _lastValidPosition = hit.point;
                return _lastValidPosition;
            }

            return _lastValidPosition;
        }
    }
}