using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Repository
{
    public class SpinRepository : ISpinRepository
    {
        public async Task<IEnumerable<Spin>> GetPreviousSpins()
        {
            return SpinsData.GetPreviousSpins();
        }

        public async Task<Spin> SpinWheel(Spin spin)
        {
            SpinsData.Add(spin);
            return spin;
        }
    }
}
