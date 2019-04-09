using System;

namespace JMAInsurance.EntityFramwork.Extensibility.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class SuppressDependencyAttribute : Attribute
    {
        public SuppressDependencyAttribute(string typeName)
        {
            TypeName = typeName;
        }

        public SuppressDependencyAttribute(Type type) : this(type.FullName)
        {
        }

        public string TypeName { get; private set; }
    }
}
