using Contracts;
using Entities.Models;
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

        public IEnumerable<Bet> GetAllBets(Guid spinId, bool trackChanges) => 
            FindAll(trackChanges)
            .Where(Id => Id.SpinId == spinId)
            .OrderBy(c => c.TimestampUtc)
            .ToList();

        public Bet GetBet(Guid betId, Guid spinId,bool trackChanges) => 
            FindByCondition(c => c.Id.Equals(betId) && c.SpinId.Equals(spinId), trackChanges)
            .SingleOrDefault();
    }
}
