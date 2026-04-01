using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

public abstract class MonoEntityView : MonoBehaviour
{
    public void Link(Entity entity)
    {
        entity.Initialized += OnEntityInitialized;
    }

    public virtual void Cleanup(Entity entity)
    {
        entity.Initialized -= OnEntityInitialized;
    }

    protected abstract void OnEntityInitialized(Entity entity);
}
