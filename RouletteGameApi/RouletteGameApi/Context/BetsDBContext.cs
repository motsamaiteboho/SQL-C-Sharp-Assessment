using Microsoft.Data.Sqlite;
using RouletteGameApi.Database;
using System.Data;

namespace RouletteGameApi.Context
{
    public class BetsDBContext
    {
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public BetsDBContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}
		public IDbConnection CreateConnection()
			=> new SqliteConnection(_connectionString);
	}
}
