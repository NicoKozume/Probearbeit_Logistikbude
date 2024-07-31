namespace Probearbeit_Logistikbude.Dtos;

public class TransactionBalanceDto
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
    /// Balance
    /// </summary>
    public long Balance { get; set; }
}