using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCompanyDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Data.Configration
{
    internal class DepartmentConfig: IEntityTypeConfiguration<Department>
    {
       
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).UseIdentityColumn(10,10);

            builder.Property(d => d.Name).IsRequired().HasMaxLength(30);
            builder.Property(d => d.Code).IsRequired().HasMaxLength(30);
            builder.Property(d => d.Description).HasMaxLength(200);
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.LastModifiiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
   
   
}
