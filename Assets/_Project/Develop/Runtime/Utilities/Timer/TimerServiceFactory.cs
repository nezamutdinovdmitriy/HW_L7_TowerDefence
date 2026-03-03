using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.Utilities.Timer
{
    public sealed class TimerServiceFactory
    {
        private readonly DIContainer _container;

        public TimerServiceFactory(DIContainer container) => _container = container;

        public TimerService Create(float cooldown)
            => new(cooldown, _container.Resolve<ICoroutinesPerformer>());
    }
}