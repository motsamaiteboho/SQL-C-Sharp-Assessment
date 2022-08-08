using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PayoutRepository : RepositoryBase<Payout>, IPayoutRepository
    {
        public PayoutRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
