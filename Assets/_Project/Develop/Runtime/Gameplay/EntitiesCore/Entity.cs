using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public sealed partial class Entity : IDisposable
    {
        public event Action<Entity> Initialized;
        public event Action<Entity> Disposed;

        private readonly ReactiveVariable<EntityHierarchy> _hierarchy = new();

        private readonly Dictionary<Type, IEntityComponent> _components = new();
        private readonly List<IEntitySystem> _systems = new();

        private readonly List<IUpdatableSystem> _updatables = new();
        private readonly List<IInitializableSystem> _initializables = new();
        private readonly List<IFixedUpdatableSystem> _fixedUpdatables = new();
        private readonly List<IDisposableSystem> _disposables = new();

        private bool _isInit;

        public Entity() => _hierarchy.Value = new();

        public bool IsInit => _isInit;

        public ReactiveVariable<EntityHierarchy> Hierarchy => _hierarchy;

        public void Initialize()
        {
            foreach (IInitializableSystem initializable in _initializables)
                initializable.OnInitialize(this);

            _isInit = true;

            Initialized?.Invoke(this);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isInit == false)
                return;

            foreach (IUpdatableSystem updatable in _updatables)
                updatable.OnUpdate(deltaTime);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_isInit == false)
                return;

            foreach (IFixedUpdatableSystem fixedUpdatable in _fixedUpdatables)
                fixedUpdatable.OnFixedUpdate(deltaTime);
        }

        public void Dispose()
        {
            Disposed?.Invoke(this);

            for (int i = _hierarchy.Value.Children.Count - 1; i == 0; i++)
                _hierarchy.Value.Children[i].Dispose();

            foreach (IDisposableSystem disposable in _disposables)
                disposable.OnDispose();

            _isInit = false;
        }

        public Entity AddComponent<TComponent>(TComponent component)
            where TComponent : class, IEntityComponent
        {
            _components.Add(typeof(TComponent), component);
            return this;
        }

        public bool HasComponent<TComponent>()
            where TComponent : class, IEntityComponent
            => _components.ContainsKey(typeof(TComponent));

        public bool TryGetComponent<TComponent>(out TComponent component)
            where TComponent : class, IEntityComponent
        {
            if(_components.TryGetValue(typeof(TComponent), out IEntityComponent findedComponent))
            {
                component = (TComponent)findedComponent;
                return true;
            }

            component = null;
            return false;
        }

        public TComponent GetComponent<TComponent>()
            where TComponent: class, IEntityComponent
        {
            if(TryGetComponent(out TComponent component) == false)
                throw new ArgumentException($"Entity not exist {typeof(TComponent)}");

            return component;
        }

        public Entity AddSystem(IEntitySystem system)
        {
            if(_systems.Contains(system))
                throw new ArgumentException(system.GetType().ToString());

            _systems.Add(system);

            if(system is IInitializableSystem initializable)
            {
                _initializables.Add(initializable);

                if (_isInit)
                    initializable.OnInitialize(this);
            }

            if (system is IUpdatableSystem updatable)
                _updatables.Add(updatable);

            if (system is IFixedUpdatableSystem fixedUpdatable)
                _fixedUpdatables.Add(fixedUpdatable);

            if (system is IDisposableSystem disposable)
                _disposables.Add(disposable);

            return this;
        }
    }
}