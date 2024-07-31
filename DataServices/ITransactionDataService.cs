using Probearbeit_Logistikbude.Models;

namespace Probearbeit_Logistikbude.DataServices;

public interface ITransactionDataService
{
    /// <summary>
    /// Gets the top three location based on the count of transactions
    /// </summary>
    public Task<IEnumerable<CarrierLocation>> GetTopThreeLocation(CancellationToken cToken);

    /// <summary>
    /// Gets unaccepted transactions of a destination location
    /// </summary>
    public Task<IEnumerable<LocationAmount>> GetUnacceptedTransactions(CancellationToken cToken);

    /// <summary>
    /// Gets the balance of all location filtered by date and type
    /// </summary>
    public Task<IEnumerable<LocationBalance>> GetBalanceOfLocation(DateTime date, LoadCarrierType type,
        CancellationToken cToken);
}