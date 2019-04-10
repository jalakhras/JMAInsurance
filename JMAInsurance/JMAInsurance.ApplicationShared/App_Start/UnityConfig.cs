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

namespace JMAInsurance.ApplicationShared
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            // context
            container.RegisterType<JMAInsuranceDbContext>();
            container.RegisterType<DbContext, JMAInsuranceDbContext>();
            //container.RegisterType<IRepository<>(), Repository<>>();
            container.RegisterType<IRepository<Applicant>, Repository<Applicant>>();
            // services
            container.RegisterType<IApplicantService, ApplicantService>();
            container.RegisterType<IEmploymentService, EmploymentService>();
            // repositories
            container.RegisterType<IRepository<Applicant>, Repository<Applicant>>();
            container.RegisterType<IRepository<Employment>, Repository<Employment>>();

            // converter
            AutoMapperConfiguration.Initialize();
            container.RegisterType<IDataConverter, DataConverter>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}