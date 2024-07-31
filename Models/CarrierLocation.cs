namespace Probearbeit_Logistikbude.Models;

/// <summary>
/// Describes a carrier with its location and transaction information
/// </summary>
public class CarrierLocation
{
    /// <summary>
    /// From location id of this carrier
    /// </summary>
    public long FromLocationId { get; set; }

    /// <summary>
    /// From location name of this carrier
    /// </summary>
    public string FromLocation { get; set; } = string.Empty;

    /// <summary>
    /// All transactions of this carrier
    /// </summary>
    public IEnumerable<Transaction> TransactionDetails { get; set; } = new List<Transaction>();

}