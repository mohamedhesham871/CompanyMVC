using Microsoft.EntityFrameworkCore;
using MVCCompanyDataAccess.Data.Configration.DepartmentConfig;
using MVCCompanyDataAccess.Data.Configration.EmployeeConfig;
using MVCCompanyDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVCCompanyDataAccess.Contexts
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        
        //public AppContext : base(options)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=Demo;Integrated Security=true");
        //    }
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);// for all Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfig).Assembly);// for specific Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfig).Assembly);// for specific Configuration

            modelBuilder.Entity<Department>().Ignore(e => e.LastModifiiedOn);

            base.OnModelCreating(modelBuilder);
        }


        public Microsoft.EntityFrameworkCore.DbSet<Department> Departments { get; set; } = null!;
        public Microsoft.EntityFrameworkCore.DbSet<Empolyee> empolyees { get; set; } = null!;
    }
}
