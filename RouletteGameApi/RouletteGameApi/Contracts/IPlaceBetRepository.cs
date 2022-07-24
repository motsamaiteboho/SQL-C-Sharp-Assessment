using RouletteGameApi.Dto;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Contracts
{
    public interface IPlaceBetRepository
    {
        Task<IEnumerable<PlaceBet>> GetPlacedBets();
        Task<PlaceBet> PlaceBet(PlaceBetDto bet);
        Task<PlaceBet> GetPlacedBet(int id);
        Task UpdateBet(int id, UpdateBetDto bet);  
        Task DeleteBet(int id);
    }
}
