using Dapper;
using RouletteGameApi.Context;
using RouletteGameApi.Contracts;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Repository
{
    public class PayoutRepository:IPayoutRepository
    {
        private readonly IBetsDBContext _context;
        public PayoutRepository(IBetsDBContext context)
        {
            _context = context;
        }

        public async Task<Payout> GetPayout(int Id)
        {
            var query = "SELECT * FROM PlacedBets WHERE  Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var placedbet = await connection.QuerySingleOrDefaultAsync<PlaceBet>(query, new { Id });
                if(placedbet is null)
                {
                    return null;
                }
                switch (placedbet.BetName)
                {
                    case nameof(BetName.split):
                        var payoutslt = new Payout() { Id =placedbet.Id, PayoutAmount= placedbet.BetAmount * 17 };
                        return payoutslt;
                    case nameof(BetName.straightup):
                        var payoutsp = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 35 };
                        return payoutsp;
                    case nameof(BetName.street):
                        var payoutst = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 11};
                        return payoutst;
                    case nameof(BetName.corner):
                        var payoutcr = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 8};
                        return payoutcr;
                    case nameof(BetName.odd):
                        var payoutod = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 1 };
                        return payoutod;
                    case nameof(BetName.even):
                        var payoutev = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 1 };
                        return payoutev;
                    default:
                        var invalidbet = new Payout();
                        return invalidbet;

                }

            }
        }

    }
}
