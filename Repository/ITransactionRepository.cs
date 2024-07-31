using Probearbeit_Logistikbude.Models;

namespace Probearbeit_Logistikbude.Repository;

public interface ITransactionRepository
{
    /// <summary>
    /// Get just all data from the json file provided with this Probearbeit
    /// </summary>
    /// <param name="cToken"></param>
    /// <returns></returns>
    public Task<IEnumerable<CarrierLocation>> GetCarrierLocations(CancellationToken cToken);
}