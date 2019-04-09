
using JMAInsurance.EntityFramwork.Extensibility.Abstractions;

namespace JMAInsurance.EntityFramwork.Localization
{
    public interface ILocalizationProvider : IDependency
    {
        string GetString(string text);
    }
}
