namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RotationDirectionProvidersHolder
    {
        private IRotationDirectionProvider _currentProvider;

        public RotationDirectionProvidersHolder(IRotationDirectionProvider rotationDirectionProvider)
            => _currentProvider = rotationDirectionProvider;

        public IRotationDirectionProvider CurrentProvider => _currentProvider;

        public void SetProvider(IRotationDirectionProvider provider) => _currentProvider = provider;
    }
}