using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CacheManager.Core;

namespace JMAInsurance.EntityFramwork.Localization
{
    public class LocalizationManager : ILocalizationManager
    {
        private readonly IEnumerable<ILocalizationProvider> providers;
        private readonly ICacheManager<string> cacheManager;

        public LocalizationManager(IEnumerable<ILocalizationProvider> providers, ICacheManager<string> cacheManager)
        {
            this.providers = providers;
            this.cacheManager = cacheManager;
        }

        public string GetString(string text)
        {
            return cacheManager.GetOrAdd(text, $"Localization_{CultureInfo.CurrentCulture.EnglishName}", (t, region) =>
             {
                 return providers.Select(x => x.GetString(text)).Where(x => x != null && !x.Equals(text, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() ?? text;
             });
        }
    }
}
