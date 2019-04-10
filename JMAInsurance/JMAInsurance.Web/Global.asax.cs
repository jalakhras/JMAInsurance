using JMAInsurance.ApplicationShared;
using JMAInsurance.Web.ConfigurationMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JMAInsurance.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           // AutoMapperConfiguration.Initialize();
            //Mapper.CreateMap<ApplicantVM, ApplicantDto>();
            //Mapper.CreateMap<VehicleVM, VehicleDto>();
            //Mapper.CreateMap<AddressVM, AddressDto>();
            //Mapper.CreateMap<EmploymentVM, EmploymentDto>();
            //Mapper.CreateMap<ProductsVM, ProductsDto>();

            //Mapper.CreateMap<Applicant, ApplicantVM>();
            //Mapper.CreateMap<Vehicle, VehicleVMDto>();
            //Mapper.CreateMap<Address, AddressVMDto>();
            //Mapper.CreateMap<Employment, EmploymentVMDto>();
            //Mapper.CreateMap<Products, ProductsVMDto>();



        }

    }
}
