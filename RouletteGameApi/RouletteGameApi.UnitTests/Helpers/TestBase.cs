using Microsoft.Extensions.Configuration;
using Moq;
using RouletteGameApi.Context;

namespace RouletteGameApi.UnitTests.Helpers
{
    public abstract class TestBase
    {
        public IBetsDBContext GetDbContext()
        {
            var mock = new Mock<IConfiguration>();
            IConfiguration configuration = mock.Object;
            var dbContext = new BetsDBContext(configuration);
            dbContext.CreateConnection();
            
            return dbContext;
        }
    }
}
