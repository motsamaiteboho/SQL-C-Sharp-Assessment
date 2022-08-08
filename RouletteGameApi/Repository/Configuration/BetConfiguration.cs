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
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasData(
                new Bet
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    BetOn = "HIGH",
                    BetValue = 50.62m,
                    BetWinnings = 560.20m,
                    TimestampUtc = DateTime.UtcNow,
                    SpinId= new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                   PayoutId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                },
                new Bet
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    BetOn = "RED",
                    BetValue = 46.45m,
                    BetWinnings = 384.78m,
                    TimestampUtc = DateTime.UtcNow,
                    SpinId = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    PayoutId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                }); ;
        }
    }
}
