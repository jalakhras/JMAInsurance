using JMAInsurance.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace JMAInsurance.EntityFramwork.DbContext
{
    public class JMAInsuranceDbContext : IdentityDbContext<IdentityUser>
    {
        public JMAInsuranceDbContext()
                : base("name=JMAInsuranceConnction")
        {
            Database.SetInitializer<JMAInsuranceDbContext>(new DropCreateDatabaseIfModelChanges<JMAInsuranceDbContext>());
        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employment> Employment { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }

    public class JMAInsuranceInitializer : DropCreateDatabaseIfModelChanges<JMAInsuranceDbContext>
    {
        protected override void Seed(JMAInsuranceDbContext context)
        {
            base.Seed(context);
        }
    }
    
}