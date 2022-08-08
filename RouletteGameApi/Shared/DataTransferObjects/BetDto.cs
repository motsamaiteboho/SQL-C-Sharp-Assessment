using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public  record BetDto(Guid Id, string BetOn, DateTime TimestampUtc, 
        decimal BetValue, decimal BetWinnings);
}
