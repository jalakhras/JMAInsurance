using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Util;
using JMAInsurance.EntityFramwork.Extensibility.Abstractions;
using JMAInsurance.EntityFramwork.Extensibility.Attributes;

namespace JMAInsurance.EntityFramwork.Extensibility
{
    public class ExtensionManager : IExtensionManager
    {
        private readonly Assembly[] extensions;
        public ExtensionManager(Assembly[] extensions)
        {
            this.extensions = extensions;
        }

        public IEnumerable<string> GetFeatures()
        {
            return (ConfigurationManager.AppSettings["Features"] ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public IEnumerable<Assembly> GetExtensions()
        {
            return new[] { typeof(HostStarter).Assembly }.Concat(extensions).Distinct();
        }

        public IEnumerable<Type> GetLoadableDependencies()
        {
            return GetExtensions().SelectMany(x => x.GetLoadableTypes()).Where(x => x.IsClass && !x.IsAbstract && x.IsAssignableTo<IDependency>());
        }

        public IEnumerable<Type> GetFilteredDependencies()
        {
            var dependencies = GetLoadableDependencies().ToList();
            var features = GetFeatures().ToArray();

            // Filter dependencies based on there features status
            var filteredDependencies = dependencies.Where(x =>
            {
                var featureAttribute = (FeatureAttribute)x.GetCustomAttribute(typeof(FeatureAttribute));
                return featureAttribute == null || features.Contains(featureAttribute.Name);
            }).OrderBy(x => x.Name);

            // Get all suppressed dependencies to exclude them from registration
            var suppressedDependencies = filteredDependencies.Select(x => (SuppressDependencyAttribute)x.GetCustomAttribute(typeof(SuppressDependencyAttribute)))
                .Where(x => x != null).Select(x => x.TypeName);

            return filteredDependencies.Where(x => !suppressedDependencies.Contains(x.FullName));
        }
    }
}
