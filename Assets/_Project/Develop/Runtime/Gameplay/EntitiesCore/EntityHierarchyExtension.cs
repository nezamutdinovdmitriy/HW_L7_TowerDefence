namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public static class EntityHierarchyExtension
    {
        public static Entity SetParent(this Entity child, Entity parent)
        {
            if (child.Hierarchy.Value == null)
                child.Hierarchy.Value = new();

            if (parent.Hierarchy.Value == null)
                parent.Hierarchy.Value = new();

            child.Hierarchy.Value.SetParent(parent);
            parent.Hierarchy.Value.AddChildren(child);

            return child;
        }
    }
}