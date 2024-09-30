using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Repository.Configuratins
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(x=>x.productBrand).WithMany()
                .HasForeignKey(x=>x.productBrandid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.productType).WithMany()
              .HasForeignKey(x => x.productTypeid)
              .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x=>x.productBrandid).IsRequired(false);
            builder.Property(x=>x.productTypeid).IsRequired(false);
        }
    }
}
