namespace Probearbeit_Logistikbude.Models;

public class LocationBalance
{
    /// <summary>
    /// LocationId
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