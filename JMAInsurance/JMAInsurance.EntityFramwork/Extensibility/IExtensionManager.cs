using System;
using System.Collections.Generic;
using System.Reflection;

namespace JMAInsurance.EntityFramwork.Extensibility
{
    public interface IExtensionManager
    {
        IEnumerable<Assembly> GetExtensions();
        IEnumerable<string> GetFeatures();
        IEnumerable<Type> GetLoadableDependencies();
        IEnumerable<Type> GetFilteredDependencies();
    }
}
