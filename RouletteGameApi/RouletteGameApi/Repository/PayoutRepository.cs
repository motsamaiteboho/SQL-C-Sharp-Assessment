using Dapper;
using RouletteGameApi.Context;
using RouletteGameApi.Contracts;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Repository
{
    public class PayoutRepository:IPayoutRepository
    {
        private readonly BetsDBContext _context;
        public PayoutRepository(BetsDBContext context)
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
                switch (placedbet.TypeOfBet)
                {
                    case nameof(TypeOfBet.split):
                        var payoutslt = new Payout() { Id =placedbet.Id, PayoutAmount= placedbet.BetAmount * 17 };
                        return payoutslt;
                    case nameof(TypeOfBet.straightup):
                        var payoutsp = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 35 };
                        return payoutsp;
                    case nameof(TypeOfBet.street):
                        var payoutst = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 11};
                        return payoutst;
                    case nameof(TypeOfBet.corner):
                        var payoutcr = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 8};
                        return payoutcr;
                    case nameof(TypeOfBet.odd):
                        var payoutod = new Payout() { Id = placedbet.Id, PayoutAmount = placedbet.BetAmount * 1 };
                        return payoutod;
                    case nameof(TypeOfBet.even):
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
