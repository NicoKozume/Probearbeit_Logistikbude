using Probearbeit_Logistikbude.Models;

namespace Probearbeit_Logistikbude.Repository;

public interface ITransactionRepository
{
    public Task<IEnumerable<CarrierLocation>> GetCarrierLocations(CancellationToken cToken);
}