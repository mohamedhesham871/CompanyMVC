using Microsoft.EntityFrameworkCore;
using MVCCompanyDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Contexts
{
    public class AppContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=Demo;Integrated Security=true");
        //    }
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public Microsoft.EntityFrameworkCore.DbSet<Department> Departments { get; set; } = null!;
    }
}
