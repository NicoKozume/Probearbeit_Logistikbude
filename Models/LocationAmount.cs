namespace Probearbeit_Logistikbude.Models;

public class LocationAmount
{
    /// <summary>
    /// Location id
    /// </summary>
    public long LocationId { get; set; }

    /// <summary>
    /// Location Name
    /// </summary>
    public string LocationName { get; set; } = string.Empty;

    /// <summary>
    /// Amount
    /// </summary>
    public long Amount { get; set; }
}