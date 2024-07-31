using System.Text.Json.Serialization;
using Probearbeit_Logistikbude.JsonHelpers;

namespace Probearbeit_Logistikbude.Models;

/// <summary>
/// Details of a particular transactions
/// </summary>
public class Transaction
{
    /// <summary>
    /// Destination Id
    /// </summary>
    [JsonPropertyName("DestinationLocationId")]
    public long DestinationLocationId { get; set; }

    /// <summary>
    /// Destination name
    /// </summary>
    [JsonPropertyName("DestinationLocationName")]
    public string DestinationLocation { get; set; } = string.Empty;

    /// <summary>
    /// Date of creation
    /// </summary>
    [JsonPropertyName("Date")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Accepted date of the transaction,
    /// if null it's not accepted
    /// </summary>
    [JsonPropertyName("AcceptedDate")]
    [JsonConverter(typeof(CustomNullableDateTimeConverter))]
    public DateTime? AcceptedDate { get; set; }

    /// <summary>
    /// Load carrier types of this transaction
    /// </summary>
    [JsonPropertyName("LoadCarriers")]
    public string LoadCarriersTransactions { get; set; } = string.Empty;
}