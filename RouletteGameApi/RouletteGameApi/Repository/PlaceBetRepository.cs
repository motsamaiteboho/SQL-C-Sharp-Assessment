using Dapper;
using Microsoft.Data.Sqlite;
using RouletteGameApi.Context;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Repository
{
    public class PlaceBetRepository : IPlaceBetRepository
    {
        private readonly BetsDBContext _context;
        public PlaceBetRepository(BetsDBContext context)
        {
            _context = context;
        }

        public async Task PlaceBet(PlaceBet bet)
        {
            var query = "INSERT INTO PlacedBets  (TypeOfBet, NumbersOnTheTable, BetAmount)" +
                "VALUES (@TypeOfBet, @NumbersOnTheTable,@BetAmount);";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, bet);
            }
        }
        public async Task<IEnumerable<PlaceBet>> GetPlacedBets()
        {
            var query = "SELECT * FROM PlacedBets";

            using (var connection = _context.CreateConnection())
            {
                var placedbets = await connection.QueryAsync<PlaceBet>(query);
                return placedbets.ToList();
            }
        }
        /*
        private readonly BetsDBContext _context;
        public PlaceBetRepository(BetsDBContext  context)
        {
            _context = context;
        }

        public async Task PlaceBet(PlaceBet bet)
        {
            var query = "INSERT INTO PlacedBets  (TypeOfBet, NumbersOnTheTable, BetAmount)" +
                "VALUES (@TypeOfBet, @NumbersOnTheTable,@BetAmount);";
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, bet);
            }
        }
        public async Task<IEnumerable<PlaceBet>> GetPlacedBets()
        {
            var query = "SELECT * FROM PlacedBets";

            using (var connection = _context.CreateConnection())
            {
                var placedbets= await connection.QueryAsync<PlaceBet>(query);
                return placedbets.ToList();
            }
        }
        
          private readonly DatabaseConfig databaseConfig;
        public PlaceBetRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task PlaceBet(PlaceBet bet)
        {
            var query = "INSERT INTO PlacedBets  (TypeOfBet, NumbersOnTheTable, BetAmount)" +
                "VALUES (@TypeOfBet, @NumbersOnTheTable,@BetAmoun);";
            using( var connection = new SqliteConnection(databaseConfig.Name))
            {
                await connection.ExecuteAsync(query, bet);
            }
        }
        public async Task<IEnumerable<PlaceBet>> GetPlacedBets()
        {
            var query = "SELECT * FROM PlacedBets";

            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                var placedbets= await connection.QueryAsync<PlaceBet>(query);
                return placedbets.ToList();
            }
        }
         */
    }
}
