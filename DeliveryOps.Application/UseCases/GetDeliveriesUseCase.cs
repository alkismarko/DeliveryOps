using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Application.UseCases;

public class GetDeliveriesUseCase
{
    private readonly IDeliveryService _deliveryService;

    public GetDeliveriesUseCase(IDeliveryService deliveryService)
    {
        _deliveryService = deliveryService;
    }

    public Task<IReadOnlyCollection<Delivery>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _deliveryService.GetDeliveriesAsync(cancellationToken);
    }
}