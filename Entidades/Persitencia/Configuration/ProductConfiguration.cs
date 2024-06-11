using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Persitencia
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityProduct) {
            entityProduct.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            entityProduct.Property(x=>x.Provider)
                .HasMaxLength(50)
                .IsRequired();
            entityProduct.Property(x=>x.Provider)
                .HasMaxLength(50)
                .IsRequired();
            entityProduct.Property(x => x.Inventory)
                .IsRequired()
                .HasMaxLength(50);
            entityProduct.Property(x => x.Amount)
                .IsRequired()
                .HasMaxLength(50);
            entityProduct.HasOne<Category>(x=>x.category)
                .WithMany(x=>x.ListProducts)
                .HasForeignKey(x=>x.categoryId);

        }
    }
}
