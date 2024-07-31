namespace Probearbeit_Logistikbude.Models;

/// <summary>
/// Details of a particular transactions
/// </summary>
public class Transaction
{
    /// <summary>
    /// Destination Id
    /// </summary>
    public long DestinationLocationId { get; set; }

    /// <summary>
    /// Destination name
    /// </summary>
    public string DestinationLocation { get; set; } = string.Empty;

    /// <summary>
    /// Date of creation
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Accepted date of the transaction,
    /// if null it's not accepted
    /// </summary>
    public DateTime? AcceptedDate { get; set; }
    
    /// <summary>
    /// Load carrier types of this transaction
    /// </summary>
    public IEnumerable<LoadCarrierTransaction> LoadCarriersTransactions { get; set; } =
        new List<LoadCarrierTransaction>();
}