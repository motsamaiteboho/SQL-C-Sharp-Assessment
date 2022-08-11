using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BetRepository : RepositoryBase<Bet>, IBetRepository
    {
        public BetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) 
        { 
        }

        public async Task<IEnumerable<Bet>> GetAllBetsAsync( bool trackChanges) => 
           await FindAll(trackChanges)
            .OrderBy(c => c.TimestampUtc)
            .ToListAsync();

        public async Task<Bet> GetBetAsync(Guid betId,bool trackChanges) => 
            await FindByCondition(c => c.Id.Equals(betId), trackChanges)
            .SingleOrDefaultAsync();

        public void PlaceBetForNextSpin(Bet bet)
        {
            Create(bet);
        }
        public async Task<IEnumerable<Bet>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
          await FindByCondition(x => ids.Contains(x.Id), trackChanges)
          .ToListAsync();
    }
}
