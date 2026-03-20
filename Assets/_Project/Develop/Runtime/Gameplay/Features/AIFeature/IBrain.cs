using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AIFeature
{
    public interface IBrain : IDisposable
    {
        public void Enable();
        public void Disable();
        public void Update(float deltaTime);
    }
}