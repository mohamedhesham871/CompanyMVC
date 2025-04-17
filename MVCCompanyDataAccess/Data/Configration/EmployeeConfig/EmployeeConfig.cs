using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCompanyDataAccess.Data.Configration.SharedConfig;
using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Data.Configration.EmployeeConfig
{
    public class EmployeeConfig : SharedConfig<Empolyee> ,IEntityTypeConfiguration<Empolyee>
    {
        public void Configure(EntityTypeBuilder<Empolyee> builder)
        {
         builder.Property(nameof(Empolyee.Name))
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("nvarchar(50)");

            builder.Property(nameof(Empolyee.Age)).IsRequired();
            
            builder.Property(nameof(Empolyee.Address)).IsRequired().HasMaxLength(150);
            
            builder.Property(nameof(Empolyee.Salary)).HasColumnType("decimal(10,2)");
            
            builder.Property(nameof(Empolyee.Email))
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(30)");
            
            builder.Property(nameof(Empolyee.PhoneNumber)).HasColumnType("varchar(11)");

            builder.Property(e => e.Gender).HasConversion(
                convertToProviderExpression: valueToAddInDb => valueToAddInDb.ToString(),
                convertFromProviderExpression: valueToReadFromDb => (Gender)Enum.Parse(typeof(Gender), valueToReadFromDb)
            );

            builder.Property(e=>e.EmployeeType)
                .HasConversion(
                               ValueToAddInDB => ValueToAddInDB.ToString(),
                                valueToReadInDB => (EmployeeType)Enum.Parse(typeof(EmployeeType), valueToReadInDB)
                );


        }

    }
}
/*
 Age Should be In Range From 24 To 50
Email Should be In Format Of Email 
Gender Will be [Male - Female]
Employee Type Should be [Parttime - Fulltime]
*/