using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISpinRepository
    {
        IEnumerable<Spin> GetAllSpins(bool trackChanges);
        Spin GetSpin(Guid spinId, bool trackChanges);  
    }
}
