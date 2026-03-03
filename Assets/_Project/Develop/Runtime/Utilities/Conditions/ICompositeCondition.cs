namespace Assets._Project.Develop.Runtime.Utilities.Conditions
{
    public interface ICompositeCondition : ICondition
    {
        public ICompositeCondition Add(ICondition condition);
        public ICompositeCondition Remove(ICondition condition);
    }
}