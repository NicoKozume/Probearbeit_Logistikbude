using Probearbeit_Logistikbude.Models;

namespace Probearbeit_Logistikbude.DataServices;

public interface ITransactionDataService
{
    public Task<IEnumerable<CarrierLocation>> GetTopThreeLocation(CancellationToken cToken);

    public Task<IEnumerable<LocationAmount>> GetUnacceptedTransactions(CancellationToken cToken);

    public Task<IEnumerable<LocationBalance>> GetBalanceOfLocation(DateTime date, LoadCarrierType type,
        CancellationToken cToken);
}