using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISpinService
    {
        IEnumerable<SpinDto> GetAllSpins(bool trackChanges);
        SpinDto GetSpin(Guid spinId, bool trackChanges);
    }
}
