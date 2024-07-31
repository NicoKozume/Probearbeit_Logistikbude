using Microsoft.AspNetCore.Mvc;
using Probearbeit_Logistikbude.DataServices;
using Probearbeit_Logistikbude.Dtos;
using Probearbeit_Logistikbude.Models;

namespace Probearbeit_Logistikbude.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ILogger<TransactionController> _logger;
    private readonly ITransactionDataService _transactionDataService;

    public TransactionController(ILogger<TransactionController> logger, ITransactionDataService transactionDataService)
    {
        _logger = logger;
        _transactionDataService = transactionDataService;
    }

    [HttpGet("TopThree", Name = "TopThree")]
    public async Task<IEnumerable<TransactionDto>> GetTopThreeLocation(CancellationToken cToken)
    {
        var data = await _transactionDataService.GetTopThreeLocation(cToken);

        var mappedData = data.Select(d => new TransactionDto()
        {
            LocationId = d.FromLocationId,
            LocationName = d.FromLocation,
            Amount = d.TransactionDetails.Count()
        });

        return mappedData;
    }
    
    [HttpGet("NotAccepted", Name = "NotAccepted")]
    public async Task<IEnumerable<TransactionDto>> GetNotAcceptedTransactions(CancellationToken cToken)
    {
        var data = await _transactionDataService.GetUnacceptedTransactions(cToken);

        var mappedData = data.Select(d => new TransactionDto()
        {
            LocationId = d.LocationId,
            LocationName = d.LocationName,
            Amount = d.Amount
        });

        return mappedData;
    }  
    
    [HttpGet("Balance" ,Name = "Balance")]
    public async Task<IEnumerable<TransactionBalanceDto>> GetBalanceOfLocation(CancellationToken cToken)
    {
        var data = await _transactionDataService.GetBalanceOfLocation(new DateTime(2024,5, 1), LoadCarrierType.EPAL, cToken);

        var mappedData = data.Select(d => new TransactionBalanceDto()
        {
            LocationId = d.LocationId,
            LocationName = d.LocationName,
            Balance = d.Balance
        });

        return mappedData;
    }
}