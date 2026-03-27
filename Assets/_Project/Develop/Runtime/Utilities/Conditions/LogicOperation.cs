namespace Assets._Project.Develop.Runtime.Utilities.Conditions
{
    public sealed class LogicOperation
    {
        public static bool And(bool a, bool b) => a && b;
        public static bool Or(bool a, bool b) => a || b;
    }
}