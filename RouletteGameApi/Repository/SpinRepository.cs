using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SpinRepository : RepositoryBase<Spin>, ISpinRepository
    {
        public SpinRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Spin> GetAllSpins(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.TimestampUtc)
            .ToList();

        public Spin GetSpin(Guid spinId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(spinId), trackChanges)
            .SingleOrDefault();
    }
}
