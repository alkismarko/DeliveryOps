using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Application.Abstractions;

public interface IDeliveryService
{
    Task<IReadOnlyCollection<Delivery>> GetDeliveriesAsync(CancellationToken cancellationToken = default);
}