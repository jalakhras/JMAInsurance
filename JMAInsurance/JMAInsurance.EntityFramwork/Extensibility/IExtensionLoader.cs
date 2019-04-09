using Autofac;

namespace JMAInsurance.EntityFramwork.Extensibility
{
    public interface IExtensionLoader
    {
        void RegisterExtensions(ContainerBuilder builder);
    }
}
