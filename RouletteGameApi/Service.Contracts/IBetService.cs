using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IBetService
    {
        Task<(IEnumerable<BetDto> bets, MetaData MetaData)> GetAllBetsAsync( BetParameters betParameters, bool trackChanges);
        Task<BetDto> GetBetAsync(Guid betId, bool trackChanges);
        Task<BetDto> PlaceBetForNextSpinAsync(BetForCreationDto betForCreation, bool trackChanges);
        Task<IEnumerable<BetDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<BetDto> bets, string ids)> CreateBetCollectionAsync(IEnumerable<BetForCreationDto> betCollection);
        Task UpdateBetAsync(Guid betid, BetForUpdateDto betForUpdate, bool trackChanges);
    }
}
