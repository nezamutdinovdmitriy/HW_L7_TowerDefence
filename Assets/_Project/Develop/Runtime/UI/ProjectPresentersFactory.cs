using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;

namespace Assets._Project.Develop.Runtime.UI
{
    public sealed class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }
    }
}