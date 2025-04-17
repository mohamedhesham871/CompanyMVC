using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCompanyDataAccess.Model.Shaerd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Data.Configration.SharedConfig
{
    public class SharedConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseClass
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.LastModifiiedOn).HasComputedColumnSql("GETDATE()");

        }
    }
}
