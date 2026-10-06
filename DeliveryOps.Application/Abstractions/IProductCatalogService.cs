using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Application.Abstractions;

public interface IProductCatalogService
{
    Task<IReadOnlyCollection<Product>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Product?> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default);
}