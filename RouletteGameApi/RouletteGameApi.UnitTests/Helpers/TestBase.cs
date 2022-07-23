using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using RouletteGameApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.UnitTests.Helpers
{
    public abstract class TestBase
    {
        public BetsDBContext GetDbContext()
        {
            var mock = new Mock<IConfiguration>();
            IConfiguration configuration = mock.Object;
            var dbContext = new BetsDBContext(configuration);
            dbContext.CreateConnection();
            
            return dbContext;
        }
    }
}
