namespace Probearbeit_Logistikbude.Models;

/// <summary>
/// Information about the load that is carried in a <see cref="Transaction"/>
/// </summary>
public class LoadCarrierTransaction
{
    /// <summary>
    /// Type of load that is carried within an <see cref="Transaction"/>
    /// </summary>
    public LoadCarrierType Type { get; set; }
    
    /// <summary>
    /// Amount of load types moved within an <see cref="Transaction"/>
    /// </summary>
    public long Amount { get; set; }
}