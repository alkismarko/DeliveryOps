using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Application.UseCases;

public class GetProductsUseCase
{
    private readonly IProductCatalogService _productCatalog;

    public GetProductsUseCase(IProductCatalogService productCatalog)
    {
        _productCatalog = productCatalog;
    }

    public Task<IReadOnlyCollection<Product>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _productCatalog.GetAllAsync(cancellationToken);
    }
}