using RouletteGameApi.Entities;

namespace RouletteGameApi.Database
{
    public class SpinsData
    {
        private static readonly List<Spin> spins = new()
        {
            new Spin { Id = Guid.NewGuid(), WinningNumber = 8 },
            new Spin { Id = Guid.NewGuid(), WinningNumber = 9 },
            new Spin { Id = Guid.NewGuid(), WinningNumber = 7 },
        };
        public static void Add(Spin spin)
        {
            spins.Add(spin);
        }

        public static List<Spin> GetPreviousSpins()
        {
            return spins;
        }
    }
}
