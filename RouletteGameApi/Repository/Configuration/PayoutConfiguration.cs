using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class PayoutConfiguration : IEntityTypeConfiguration<Payout>
    {
        public void Configure(EntityTypeBuilder<Payout> builder)
        {
            builder.HasData(
                new Payout
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    TimestampUtc = DateTime.UtcNow,
                },
                new Payout
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    TimestampUtc = DateTime.UtcNow,
                });
        }
    }
}
