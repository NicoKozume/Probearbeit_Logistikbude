using System.Text.Json.Serialization;

namespace Probearbeit_Logistikbude.Models;

/// <summary>
/// Describes a carrier with its location and transaction information
/// </summary>
public class CarrierLocation
{
    /// <summary>
    /// From location id of this carrier
    /// </summary>
    [JsonPropertyName("FromLocationId")]
    public long FromLocationId { get; set; }

    /// <summary>
    /// From location name of this carrier
    /// </summary>
    [JsonPropertyName("FromLocationName")]
    public string FromLocation { get; set; } = string.Empty;

    /// <summary>
    /// All transactions of this carrier
    /// </summary>
    [JsonPropertyName("TransactionDtos")]
    public Transaction[] TransactionDetails { get; set; } = Array.Empty<Transaction>();

}