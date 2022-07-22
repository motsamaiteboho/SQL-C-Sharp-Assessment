using RouletteGameApi.Context;
using RouletteGameApi.Contracts;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BetsDBContext _context;
        private PayoutRepository _payoutRepository;
        private PlaceBetRepository _placeBetRepository;
        private SpinRepository _spinRepository;
        public RepositoryWrapper(BetsDBContext context)
        {
            _context = context;
        }
       
        public IPayoutRepository Payout
        {
            get {
                if(_payoutRepository == null)
                {
                    _payoutRepository = new PayoutRepository(_context);
                }
                return _payoutRepository; 
            }
        }

        public IPlaceBetRepository PlaceBet
        {
            get
            {
                if(_placeBetRepository == null)
                {
                    _placeBetRepository = new PlaceBetRepository(_context);
                }
                return (_placeBetRepository);
            }
        }

        public ISpinRepository spin
        {
            get
            {
                if(_spinRepository == null)
                {
                    _spinRepository = new SpinRepository();
                }
                return (_spinRepository);
            }
        }
    }
}
