using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IBetService
    {
        IEnumerable<BetDto> GetAllBets(Guid spinId, bool trackChanges);
        BetDto GetBet(Guid betId, Guid spinId, bool trackChanges);
    }
}
