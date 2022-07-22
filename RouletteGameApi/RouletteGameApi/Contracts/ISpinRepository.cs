using RouletteGameApi.Entities;

namespace RouletteGameApi.Contracts
{
    public interface ISpinRepository
    {
        Task<Spin> SpinWheel(Spin spin);
        Task<IEnumerable<Spin>> GetPreviousSpins();
    }
}
