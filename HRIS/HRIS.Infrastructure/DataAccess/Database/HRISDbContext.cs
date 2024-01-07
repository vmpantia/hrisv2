using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Entities.Versions;
using HRIS.Infrastructure.DataAccess.Stubs;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.DataAccess.Database
{
    public class HRISDbContext : DbContext
    {
        private readonly List<Config> _initialConfigs;
        private readonly List<Employee> _stubEmployees;
        private readonly List<Contact> _stubContacts;
        private readonly List<Address> _stubAddresses;
        public HRISDbContext(DbContextOptions options) : base(options)
        {
            #region Initial Data
            _initialConfigs = new List<Config>
            {
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_FORMAT", Value = "{0}-{1}-{2}" },
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_DIGIT", Value = "7" },
                new Config { Section = "SYSTEM", Key = "ID_NUMBER_EMPLOYEE_PREFIX", Value = "EMP" },
                new Config { Section = "SYSTEM", Key = "COMPANY_DOMAIN", Value = "companydomain.com.ph" },
            };
            #endregion

            #region Stub Data
            _stubEmployees = StubData.FakerEmployee()
                                     .Generate(100);
            _stubContacts = StubData.FakerContact(_stubEmployees.Select(data => data.Id).ToList())
                                     .Generate(50);
            _stubAddresses = StubData.FakerAddress(_stubEmployees.Select(data => data.Id).ToList())
                                     .Generate(50);
            #endregion
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        #region Version Tables
        public DbSet<EmployeeVersion> EmployeeVersions { get; set; }
        public DbSet<ContactVersion> ContactVersions { get; set; }
        public DbSet<AddressVersion> AddressVersions { get; set; }
        #endregion

        public DbSet<AppLog> AppLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table Configurations
            modelBuilder.Entity<Employee>()
                .HasMany(emp => emp.Contacts)
                .WithOne(con => con.Employee)
                .HasForeignKey(con => con.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(emp => emp.Addresses)
                .WithOne(add => add.Employee)
                .HasForeignKey(add => add.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .HasOne(con => con.Employee)
                .WithMany(emp => emp.Contacts)
                .HasForeignKey(con => con.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .HasOne(add => add.Employee)
                .WithMany(emp => emp.Addresses)
                .HasForeignKey(add => add.EmployeeId)
                .IsRequired();
            #endregion

            #region Data Seeding
            #region Initial Data
            modelBuilder.Entity<Config>().HasData(_initialConfigs);
            #endregion

            #region Stub Data
            modelBuilder.Entity<Employee>().HasData(_stubEmployees);
            modelBuilder.Entity<Contact>().HasData(_stubContacts);
            modelBuilder.Entity<Address>().HasData(_stubAddresses);
            #endregion
            #endregion
        }
    }
}
