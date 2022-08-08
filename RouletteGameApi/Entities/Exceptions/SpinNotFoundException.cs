﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class SpinNotFoundException : NotFoundException
    {
        public SpinNotFoundException(Guid spinId) :
            base($"The spin with id: {spinId} doesn't exist in the database.")
        {
        }
    }
}
