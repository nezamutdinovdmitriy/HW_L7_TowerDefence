using System;

namespace Assets._Project.Develop.Runtime.Utilities.Reactive
{
    public sealed class Subscriber : IDisposable
    {
        private readonly Action _action;
        private readonly Action<Subscriber> _onDispose;

        public Subscriber(
            Action action, 
            Action<Subscriber> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Dispose() => _onDispose?.Invoke(this);
        public void Invoke() => _action?.Invoke();
    }

    public sealed class Subscriber<TArg> : IDisposable
    {
        private readonly Action<TArg> _action;
        private readonly Action<Subscriber<TArg>> _onDispose;

        public Subscriber(
            Action<TArg> action,
            Action<Subscriber<TArg>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Dispose() => _onDispose?.Invoke(this);
        public void Invoke(TArg arg) => _action?.Invoke(arg);
    }

    public sealed class Subscriber<TArg, TArg2> : IDisposable
    {
        private readonly Action<TArg, TArg2> _action;
        private readonly Action<Subscriber<TArg, TArg2>> _onDispose;

        public Subscriber(
            Action<TArg, TArg2> action,
            Action<Subscriber<TArg, TArg2>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Dispose() => _onDispose?.Invoke(this);
        public void Invoke(TArg arg, TArg2 arg2) => _action?.Invoke(arg, arg2);
    }
}