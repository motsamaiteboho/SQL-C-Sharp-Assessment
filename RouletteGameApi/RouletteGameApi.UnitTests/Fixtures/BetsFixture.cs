﻿using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.UnitTests.Fixtures
{
    public class BetsFixture
    {
        public static List<BetDto> GetAllBets()
        {
            return new List<BetDto>
            {
                  new BetDto
                  {
                        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        BetOn = "HIGH",
                        BetValue = 50.62m,
                        TimestampUtc = DateTime.UtcNow
                   },
                   new BetDto
                   {
                        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        BetOn = "RED",
                        BetValue = 46.45m,
                        TimestampUtc = DateTime.UtcNow,
                   }
            };
        }
        public static BetDto GetBet(Guid id)
        {
            return GetAllBets().Find(x => x.Id == id);
        }
        public static BetDto GetNextSpin()
        {
            return new BetDto
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                BetOn = "HIGH",
                BetValue = 50.62m,
                TimestampUtc = DateTime.UtcNow
            };
        }
    }
}
