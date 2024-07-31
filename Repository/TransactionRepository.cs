using System.Text.Json;
using System.Text.Json.Serialization;
using Probearbeit_Logistikbude.Models;

namespace Probearbeit_Logistikbude.Repository;

public class TransactionRepository : ITransactionRepository
{
    private const string JSON_FILE_PATH = "./logistikbude_exercise.json";
    
    /// <inheritdoc/>
    public async Task<IEnumerable<CarrierLocation>> GetCarrierLocations(CancellationToken cToken)
    {
        var jsonStream = new FileStream(JSON_FILE_PATH, FileMode.Open);

        var allData = await JsonSerializer.DeserializeAsync<IEnumerable<CarrierLocation>>(jsonStream, cancellationToken: cToken);

        if (allData == null)
        {
            throw new Exception("Reading json file returned NULL");
        }
        
        return allData;
    }
}