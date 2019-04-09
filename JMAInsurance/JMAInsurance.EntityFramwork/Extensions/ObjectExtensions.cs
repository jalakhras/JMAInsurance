namespace JMAInsurance.Framework.Extensions
{
    public static class ObjectExtensions
    {
        public static bool Is<T>(this object obj) where T : class
        {
            return obj is T;
        }

        public static T As<T>(this object obj) where T : class
        {
            return obj as T;
        }
    }
}
