using EPM.Models;
using System.Data.Entity;

namespace JMAInsurance.Core
{
    public class MigrationContext : IDbContext
    {
        public void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}