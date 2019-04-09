using System;
using System.Collections.Generic;

namespace JMAInsurance.EntityFramwork.Extensibility.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAbstractClasses(this Type type)
        {
            // is there any base type?
            if ((type == null) || (type.BaseType == null))
            {
                yield break;
            }

            // return all inherited abstract types
            var baseType = type.BaseType;
            while (baseType != null)
            {
                if (baseType.IsAbstract)
                    yield return baseType;
                baseType = baseType.BaseType;
            }
        }
    }
}
