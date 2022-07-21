using RouletteGameApi.Entities;

namespace RouletteGameApi.Contracts
{
    public interface IPlaceBetRepository
    {
        Task<IEnumerable<PlaceBet>> GetPlacedBets();
        Task PlaceBet(PlaceBet bet);
    }
}
