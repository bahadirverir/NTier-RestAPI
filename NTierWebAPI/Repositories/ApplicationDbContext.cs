using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using Repositories.SeedData;

namespace Repositories
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.SetNull);  

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobID)         
                .OnDelete(DeleteBehavior.SetNull);   

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Department)           
                .WithMany(d => d.Jobs)               
                .HasForeignKey(j => j.DepartmentID)  
                .OnDelete(DeleteBehavior.Cascade);   

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.DepartmentName) 
                .IsUnique();

            modelBuilder.Entity<Job>()
                .HasIndex(j => j.JobTitle) 
                .IsUnique();

            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    } 
}   