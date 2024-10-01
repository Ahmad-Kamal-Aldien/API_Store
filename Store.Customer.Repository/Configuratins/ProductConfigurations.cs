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
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(x=>x.Brand).WithMany()
                .HasForeignKey(x=>x.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Type).WithMany()
              .HasForeignKey(x => x.TypeId)
              .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x=>x.BrandId).IsRequired(false);
            builder.Property(x=>x.TypeId).IsRequired(false);
        }
    }
}
