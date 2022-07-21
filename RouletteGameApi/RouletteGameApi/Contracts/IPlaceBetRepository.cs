using RouletteGameApi.Dto;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Contracts
{
    public interface IPlaceBetRepository
    {
        public Task<IEnumerable<PlaceBet>> GetPlacedBets();
        public Task<PlaceBet> GetPlacedBet(int id);
        public Task<PlaceBet> PlaceBet(PlaceBetDto bet);
        public  Task UpdateBet(int id, UpdateBetDto bet);  
        public Task DeleteBet(int id);
    }
}
