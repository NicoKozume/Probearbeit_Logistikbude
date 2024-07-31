namespace Probearbeit_Logistikbude.Dtos;

/// <summary>
/// Transaction dto; can be used for displaying stuff about transactions
/// </summary>
public class TransactionDto
{
    /// <summary>
    /// Location Id
    /// </summary>
    public long LocationId { get; set; }

    /// <summary>
    /// Location Name
    /// </summary>
    public string LocationName { get; set; } = string.Empty;

    /// <summary>
    /// Amount
    /// </summary>
    public int Amount { get; set; }
}