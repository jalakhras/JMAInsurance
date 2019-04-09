using System;

namespace JMAInsurance.EntityFramwork.Extensibility.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FeatureAttribute : Attribute
    {
        public FeatureAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
