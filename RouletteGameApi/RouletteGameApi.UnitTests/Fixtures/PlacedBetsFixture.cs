using RouletteGameApi.Entities;

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
                   BetName = "split",
                   NumbersOnTheTable = 5,
                   BetAmount = 20
                   
               },
               new PlaceBet
               {
                   Id = 2,
                   BetName = "strightup",
                   NumbersOnTheTable = 5,
                   BetAmount = 20

               },
               new PlaceBet
               {
                   Id = 3,
                   BetName = "even",
                   NumbersOnTheTable = 4,
                   BetAmount = 76.84m

               },
               new PlaceBet
               {
                   Id = 3,
                   BetName = "odd",
                   NumbersOnTheTable = 13,
                   BetAmount = 50.54m

               },
           };
    }
}
