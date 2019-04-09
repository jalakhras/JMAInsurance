using JMAInsurance.Framework.Extensibility.Abstractions;

namespace JMAInsurance.Application.Services.Interface

{
    public interface IAddressServices : IDependency
    {
        void GetAll();
    }
}
