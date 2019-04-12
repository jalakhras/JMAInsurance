using JMAInsurance.Entity;
using System.Data.Entity;

namespace JMAInsurance.EntityFramwork.DbContext
{
    public class JMAInsuranceDbContext : System.Data.Entity.DbContext
    {
        public JMAInsuranceDbContext()
                : base("name=JMAInsuranceConnction")
        {
            Database.Initialize(false);
        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ErrorLog> Errors { get; set; }
    }

    public class JMAInsuranceInitializer : DropCreateDatabaseIfModelChanges<JMAInsuranceDbContext>
    {
        protected override void Seed(JMAInsuranceDbContext context)
        {
            base.Seed(context);
        }
    }
    
}