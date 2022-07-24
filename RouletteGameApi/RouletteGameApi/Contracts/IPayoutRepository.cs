using RouletteGameApi.Entities;

namespace RouletteGameApi.Contracts
{
    public interface IPayoutRepository
    {
         Task<Payout> GetPayout(int id);

    }
}
