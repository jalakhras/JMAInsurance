using JMAInsurance.EntityFramwork.Extensibility.Abstractions;

namespace JMAInsurance.EntityFramwork.Localization
{
    public interface ILocalizationManager : IDependency
    {
        string GetString(string text);
    }
}
