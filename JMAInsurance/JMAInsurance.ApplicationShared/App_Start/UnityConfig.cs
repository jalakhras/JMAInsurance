using JMAInsurance.EntityFramwork.DbContext;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using JMAInsurance.ApplicationShared.ConfigurationMapper;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Entity;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Application.Service.Employments;
using JMAInsurance.Application.Service.Products;
using JMAInsurance.Application.Service.Address;
using JMAInsurance.Application.Service.Vehicle;

namespace JMAInsurance.ApplicationShared
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
             // context
            container.RegisterType<JMAInsuranceDbContext>();
            container.RegisterType<DbContext, JMAInsuranceDbContext>();
            //container.RegisterType<IRepository<>(), Repository<>>();
            
            // services
            container.RegisterType<IApplicantService, ApplicantService>();
            container.RegisterType<IEmploymentService, EmploymentService>();
            container.RegisterType<IProductsService, ProductsService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IVehicleService, VehicleService>();
            // repositories
            container.RegisterType<IRepository<Applicant>, Repository<Applicant>>();
            container.RegisterType<IRepository<Employment>, Repository<Employment>>();
            container.RegisterType<IRepository<Products>, Repository<Products>>();
            container.RegisterType<IRepository<Address>, Repository<Address>>();
            container.RegisterType<IRepository<Vehicle>, Repository<Vehicle>>();
            // converter
            AutoMapperConfiguration.Initialize();
            container.RegisterType<IDataConverter, DataConverter>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}