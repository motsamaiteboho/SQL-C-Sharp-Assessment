namespace RouletteGameApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IPayoutRepository Payout { get; }
        IPlaceBetRepository PlaceBet { get; }
        ISpinRepository spin { get; }
    }
}
