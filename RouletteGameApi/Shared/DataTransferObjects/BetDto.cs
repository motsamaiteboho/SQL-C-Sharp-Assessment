﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public  record BetDto 
    {
        public Guid Id { get; init; }
        public string? BetOn { get; init; }
        public DateTime TimestampUtc { get; init; }
        public decimal BetValue { get; init; }
        public decimal BetinniWngs  { get; init; }
    }
}
