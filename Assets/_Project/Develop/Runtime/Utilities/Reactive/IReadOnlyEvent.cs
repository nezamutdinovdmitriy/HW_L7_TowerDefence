using System;

namespace Assets._Project.Develop.Runtime.Utilities.Reactive
{
    public interface IReadOnlyEvent
    {
        public IDisposable Subscribe(Action action);
    }

    public interface IReadOnlyEvent<T>
    {
        public IDisposable Subscribe(Action<T> action);
    }
}