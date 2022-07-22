using RouletteGameApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.UnitTests.Fixtures
{
    public static class PlacedBetsFixture
    {
        public static List<PlaceBet> GetTestPlacesBets() =>
           new()
           {
               new PlaceBet
               {
                   Id = 1,
                   TypeOfBet = "split",
                   NumbersOnTheTable = 5,
                   BetAmount = 20
                   
               },
               new PlaceBet
               {
                   Id = 2,
                   TypeOfBet = "strightup",
                   NumbersOnTheTable = 5,
                   BetAmount = 20

               },
               new PlaceBet
               {
                   Id = 3,
                   TypeOfBet = "even",
                   NumbersOnTheTable = 4,
                   BetAmount = 76.84m

               },
               new PlaceBet
               {
                   Id = 3,
                   TypeOfBet = "odd",
                   NumbersOnTheTable = 13,
                   BetAmount = 50.54m

               },
           };
    }
}
