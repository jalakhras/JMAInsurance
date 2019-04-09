using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using JMAInsurance.Entity;
using JMAInsurance.Entity.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EPM.Models
{
    public class JMAInsuranceContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>, IDbContext
    {
        public static JMAInsuranceContext Create()
        {
            return new JMAInsuranceContext();
        }
        public JMAInsuranceContext() : base("name=JMAInsuranceConnction")
        {

        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var conv = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>("SoftDeleteColumnName", (type, attributes) => attributes.Single().ColumnName);
            modelBuilder.Conventions.Add(conv);

          

        }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entity in modifiedEntities)
            {
                if (entity.Entity is IAuditable)
                {
                    CreateHistoryRecord(entity);
                }
            }

            return base.SaveChanges();
        }

        private void CreateHistoryRecord(DbEntityEntry entity)
        {

            var type = ObjectContext.GetObjectType(entity.Entity.GetType());

            var instance = Activator.CreateInstance(type);

            foreach (var properyName in entity.OriginalValues.PropertyNames)
            {
                type.InvokeMember(properyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, instance, new object[] { entity.OriginalValues[properyName] });
            }
            var key = type.GetProperties().FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));

            type.InvokeMember("ReferenceId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, instance, new object[] { entity.OriginalValues[key.Name] });
            type.InvokeMember("IsDeleted", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, instance, new object[] { true });


            Entry(instance).State = EntityState.Added;
        }
    }

}