using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Application.UseCases;

public class GetDeliveriesUseCase
{
    private readonly IDeliveryRepository _deliveryRepository;
    public GetDeliveriesUseCase(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }

    public Task<IReadOnlyCollection<Delivery>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _deliveryRepository.GetAllAsync(cancellationToken);
    }
}