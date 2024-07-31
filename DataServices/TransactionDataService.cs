using Probearbeit_Logistikbude.Models;
using Probearbeit_Logistikbude.Repository;

namespace Probearbeit_Logistikbude.DataServices;

public class TransactionDataService : ITransactionDataService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionDataService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }


    public async Task<IEnumerable<CarrierLocation>> GetTopThreeLocation(CancellationToken cToken)
    {
        var allTransaction = await _transactionRepository.GetCarrierLocations(cToken);

        var sortedByTransactionAmount = allTransaction.OrderByDescending(x => x.TransactionDetails.Count());

        var topThreeLocations = sortedByTransactionAmount.Take(3);

        return topThreeLocations;
    }

    public async Task<IEnumerable<LocationAmount>> GetUnacceptedTransactions(CancellationToken cToken)
    {
        var allTransaction = await _transactionRepository.GetCarrierLocations(cToken);

        var unacceptedTransactions = allTransaction.SelectMany(x => x.TransactionDetails)
            .Where(x => x.AcceptedDate == null)
            .GroupBy(x => x.DestinationLocationId);

        return unacceptedTransactions.Select(x => new LocationAmount()
        {
            LocationId = x.Key,
            LocationName = x.FirstOrDefault()?.DestinationLocation ?? string.Empty,
            Amount = x.Count()
        });

    }

    public async Task<IEnumerable<LocationBalance>> GetBalanceOfLocation(DateTime date, LoadCarrierType type, CancellationToken cToken)
    {
        var allTransaction = await _transactionRepository.GetCarrierLocations(cToken);

        return (from transaction in allTransaction 
                let relevantOutBoundTransaction = transaction.TransactionDetails.Where(x => x.Date <= date) 
                let outBoundAmount = GetAmount(relevantOutBoundTransaction) 
                let relevantInboundTransactions = allTransaction.SelectMany(x => x.TransactionDetails.Where(y => y.DestinationLocationId == transaction.FromLocationId)) 
                let inBoundAmount = GetAmount(relevantInboundTransactions) 
                select new LocationBalance()
                {
                    LocationId = transaction.FromLocationId, 
                    LocationName = transaction.FromLocation, 
                    Balance = inBoundAmount - outBoundAmount
                }).ToList();
        
        long GetAmount(IEnumerable<Transaction> transactions)
        {
            return transactions.SelectMany(x => MapToLoadCarrierTransaction(x.LoadCarriersTransactions))
                    .Where(x => x.Type == type)
                    .Sum(x => x.Amount);
        }
        
    }


    private static IEnumerable<LoadCarrierTransaction> MapToLoadCarrierTransaction(string loadCarrier)
    {
        if (string.IsNullOrEmpty(loadCarrier))
        {
            return Enumerable.Empty<LoadCarrierTransaction>();
        }
        var splittedValues = loadCarrier.Split(",");
        return splittedValues.Select(value => new LoadCarrierTransaction()
        {
            Type = Enum.Parse<LoadCarrierType>(value[(value.IndexOf("x", StringComparison.Ordinal) + 1)..]),
            Amount = long.Parse(value[..value.IndexOf("x", StringComparison.Ordinal)])
        });
    }
}