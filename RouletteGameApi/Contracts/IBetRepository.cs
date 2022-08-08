using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBetRepository
    {
        IEnumerable<Bet> GetAllBets(Guid spinId, bool trackChanges);
        Bet GetBet(Guid betId, Guid spinId, bool trackChanges);
    }
}
