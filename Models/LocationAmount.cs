namespace Probearbeit_Logistikbude.Models;

public class LocationAmount
{
    public long LocationId { get; set; }

    public string LocationName { get; set; } = string.Empty;

    public long Amount { get; set; }
}