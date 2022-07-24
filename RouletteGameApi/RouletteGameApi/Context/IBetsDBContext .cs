using System.Data;

namespace RouletteGameApi.Context
{
    public interface IBetsDBContext
    {
        IDbConnection CreateConnection();
    }
}
