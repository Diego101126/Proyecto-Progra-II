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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>

    {
        public void Configure(EntityTypeBuilder<Client> entityClient)
        {
            entityClient.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            entityClient.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entityClient.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);
            entityClient.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);
            entityClient.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
