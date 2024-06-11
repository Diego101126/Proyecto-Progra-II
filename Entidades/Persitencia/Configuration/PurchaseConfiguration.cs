using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Persitencia
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> entityPurchase) {
            entityPurchase.Property(x => x.DatePurchase)
                .IsRequired()
                .HasMaxLength(50);
            entityPurchase.HasOne<Client>(x => x.client)
                .WithMany(x => x.ListPurchases)
                .HasForeignKey(x => x.clientId);
               
        }
    }
}
