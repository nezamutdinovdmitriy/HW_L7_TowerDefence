namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems
{
    public interface IInitializableSystem : IEntitySystem
    {
        public void OnInitialize(Entity entity);
    }
}