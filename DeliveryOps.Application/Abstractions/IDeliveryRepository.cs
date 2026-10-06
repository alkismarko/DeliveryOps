using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Application.Abstractions;

public interface IDeliveryRepository
{
    Task<IReadOnlyCollection<Delivery>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Delivery> AddAsync(
        Delivery delivery,
        CancellationToken cancellationToken = default);
}