using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Persitencia.Configuration
{
    public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> entityPurchaseDetail)
        {
            entityPurchaseDetail.Property(x => x.Amount)
                .IsRequired()
                .HasMaxLength(50);
            entityPurchaseDetail.Property(x => x.Price)
                .IsRequired()
                .HasMaxLength(50);
            entityPurchaseDetail.Property(x => x.payment)
                .IsRequired()
                .HasMaxLength(50);
            //entityPurchaseDetail.Property(x => x.Iva)
            //    .IsRequired()
            //    .HasMaxLength(50);
            //entityPurchaseDetail.Property(x => x.Descount)
            //    .IsRequired()
            //    .HasMaxLength(50);
            //entityPurchaseDetail.Property(x => x.total)
            //    .IsRequired()
            //    .HasMaxLength(50);
            entityPurchaseDetail.HasOne<Purchase>(x => x.purchase)
                .WithMany(x => x.ListpurchaseDetail)
                .HasForeignKey(x => x.purchaseId);
            entityPurchaseDetail.HasOne<Product>(x => x.product)
                .WithMany(x => x.ListpurchaseDetails)
                .HasForeignKey(x => x.productId);

        }

    }
}
