namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public static class EntityHierarchyExt
    {
        public static Entity SetParent(this Entity child, Entity parent)
        {
            child.Hierarchy.Value.SetParent(parent);
            parent.Hierarchy.Value.AddChildren(child);

            return child;
        }
    }
}