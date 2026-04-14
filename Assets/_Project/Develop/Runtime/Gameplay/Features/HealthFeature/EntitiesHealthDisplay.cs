using Assets._Project.Develop.Runtime.UI.CommonViews;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public class EntitiesHealthDisplay : ElementsListView<BarWithText>
    {
        private Camera _camera;

        private void Awake() => _camera = Camera.main;

        public void UpdatePositionFor(BarWithText bar, Vector3 wolrdPosition)
        {
            Vector3 position = _camera.WorldToScreenPoint(wolrdPosition);

            bar.transform.position = position;
        }
    }
}