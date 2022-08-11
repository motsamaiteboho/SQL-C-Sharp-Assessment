using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PayoutDto
    {
        public Guid Id { get; init; }
        public DateTime TimestampUtc { get; init; }
        public decimal TotalPayout { get; init; }
    }
}
