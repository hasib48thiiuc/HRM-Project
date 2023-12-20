using Microsoft.EntityFrameworkCore;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Models
{
    public class TabulatorDbContext : DbContext
    {
        public TabulatorDbContext(DbContextOptions<TabulatorDbContext> opts) : base(opts)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; } 

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<AttendanceSummary> AttendanceSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
          .HasKey(a => new { a.ComId, a.EmpId, a.DtDate });
            modelBuilder.Entity<AttendanceSummary>()
         .HasKey(asum => new { asum.ComId, asum.EmpId, asum.DtYear, asum.DtMonth });
            modelBuilder.Entity<Company>()
                .HasMany(d => d.Departments)
                .WithOne(y => y.Company)
                .HasForeignKey(a => a.CompanyId);

            // Configure Company-Department relationship (One-to-Many)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Company)
                .WithMany(c => c.Departments)  
                .HasForeignKey(d => d.CompanyId);

                    modelBuilder.Entity<Employee>()
             .HasOne(e => e.Department)
                  .WithMany(d => d.Employees)
                  .HasForeignKey(e => e.DeptId)
              .OnDelete(DeleteBehavior.NoAction);

















        }



    }
}
