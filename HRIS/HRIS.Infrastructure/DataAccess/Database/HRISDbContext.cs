using HRIS.Domain.Models.Entities;
using HRIS.Infrastructure.DataAccess.Stubs;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.DataAccess.Database
{
    public class HRISDbContext : DbContext
    {
        private readonly List<Config> _initialConfigs;
        private readonly List<Employee> _stubEmployees;
        public HRISDbContext(DbContextOptions options) : base(options)
        {
            #region Initial Data
            _initialConfigs = new List<Config>
            {
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_FORMAT", Value = "{0}-{1}-{2}" },
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_DIGIT", Value = "7" },
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_EMPPLOYEE_PREFIX", Value = "EMP" },
            };
            #endregion

            #region Stub Data
            _stubEmployees = StubData.FakerEmployee()
                                     .Generate(100);
            #endregion
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

            #region Stub Data
            modelBuilder.Entity<Employee>().HasData(_stubEmployees);
            #endregion

            #endregion
        }
    }
}
