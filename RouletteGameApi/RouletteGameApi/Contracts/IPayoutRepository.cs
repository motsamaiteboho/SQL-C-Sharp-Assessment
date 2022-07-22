using RouletteGameApi.Entities;

namespace RouletteGameApi.Contracts
{
    public interface IPayoutRepository
    {
        public Task<Payout> GetPayout(int id);

    }
}
