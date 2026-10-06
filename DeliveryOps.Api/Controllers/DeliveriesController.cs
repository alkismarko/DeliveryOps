using DeliveryOps.Application.UseCases;
using DeliveryOps.Contracts.Deliveries; 
using Microsoft.AspNetCore.Mvc;

namespace DeliveryOps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveriesController : ControllerBase
{
    private readonly GetDeliveriesUseCase _getDeliveriesUseCase;

    public DeliveriesController(
        GetDeliveriesUseCase getDeliveriesUseCase)
    {
        _getDeliveriesUseCase = getDeliveriesUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<DeliveryDto>>> Get(
        CancellationToken cancellationToken)
    {
        var deliveries =
            await _getDeliveriesUseCase.ExecuteAsync(cancellationToken);

        var result = deliveries
            .Select(delivery => new DeliveryDto
            {
                Id = delivery.Id,
                CustomerName = delivery.CustomerName,
                CustomerPhone = delivery.CustomerPhone,
                DeliveryDate = delivery.DeliveryDate,

                Status = delivery.Status.ToString(),
                Priority = delivery.Priority.ToString(),

                ProductCode = delivery.Product.Code,
                ProductName = delivery.Product.Name,

                PackageSize = delivery.PackageSize.ToString(),
                TransportType = delivery.TransportType.ToString()
            })
            .ToList();

        return Ok(result);
    }
}