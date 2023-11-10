using HRIS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.DataAccess.Database
{
    public class HRISDbContext : DbContext
    {
        private readonly List<Config> _initialConfigs;
        public HRISDbContext(DbContextOptions options) : base(options)
        {
            _initialConfigs = new List<Config>
            {
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_FORMAT", Value = "{0}-{1}-{2}" },
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_DIGIT", Value = "7" },
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_EMPPLOYEE_PREFIX", Value = "EMP" },
            };
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeVersion> EmployeeVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Data Seeding

            #region Initial Data
            modelBuilder.Entity<Config>().HasData(_initialConfigs);
            #endregion

            #endregion
        }
    }
}
