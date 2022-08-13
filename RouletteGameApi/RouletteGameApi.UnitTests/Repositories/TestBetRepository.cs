using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Repository;
using RouletteGameApi.UnitTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RouletteGameApi.UnitTests.Repositories
{
    public class TestBetRepository : IDisposable
    {
        protected readonly RepositoryContext _context;
        public TestBetRepository()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source= TestRouletteDB.db")
                .Options;

            _context = new RepositoryContext(options);
            _context.Database.EnsureCreated();
        }

        //[Fact]
        //public async Task SaveAsync_AdddNewBet()
        //{
        //    //Arrange
        //    var newBet = BetsFixture.NewTodo();
        //    _context.Bets.Add(BetsFixture.NewTodo());
        //    _context.SaveChanges();

        //    var sut = new BetRepository(_context);

        //    //Act
        //     sut.Create(newBet);

        //    //Assert
        //    int expectedRecordCount = 4;
        //    _context.Bets.Count().Should().Be(expectedRecordCount);
        //}

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();

        }
    }
}
