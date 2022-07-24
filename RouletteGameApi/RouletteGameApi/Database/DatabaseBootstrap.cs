using Dapper;
using RouletteGameApi.Context;

namespace RouletteGameApi.Database
{
    public class DatabaseBootstrap: IDatabaseBootstrap
    {
        private readonly IBetsDBContext  _context;

        public DatabaseBootstrap(IBetsDBContext context)
        {
            _context = context;
        }

        public void Setup()
        {
            using var connection = _context.CreateConnection();

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'PlacedBets';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "PlacedBets")
                return;

            connection.Execute("Create Table PlacedBets (" +
                "Id INTEGER PRIMARY KEY  AUTOINCREMENT ," +
                "BetName VARCHAR(50) NOT NULL," +
                "NumbersOnTheTable INTEGER NOT NULL," +
                "BetAmount DECIMAL(8,2) NOT NULL);");

            connection.Close();
        }
    }
}
