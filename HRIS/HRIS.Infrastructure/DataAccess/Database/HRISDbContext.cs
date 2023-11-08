using HRIS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.DataAccess.Database
{
    public class HRISDbContext : DbContext
    {
        public HRISDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeVersion> EmployeeVersions { get; set; }
    }
}
