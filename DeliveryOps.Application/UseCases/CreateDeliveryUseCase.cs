using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;
using DeliveryOps.Domain.Enums;
using DeliveryOps.Domain.Services;

namespace DeliveryOps.Application.UseCases;

public class CreateDeliveryUseCase
{
    private readonly IProductCatalogService _productCatalog;
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly PackageRuleService _packageRuleService;

    public CreateDeliveryUseCase(
        IProductCatalogService productCatalog,
        IDeliveryRepository deliveryRepository,
        PackageRuleService packageRuleService)
    {
        _productCatalog = productCatalog;
        _deliveryRepository = deliveryRepository;
        _packageRuleService = packageRuleService;
    }

    public async Task<Delivery> ExecuteAsync(
        CreateDeliveryRequest request,
        CancellationToken cancellationToken = default)
    {
        var product = await _productCatalog.GetByCodeAsync(
            request.ProductCode,
            cancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException(
                $"Product '{request.ProductCode}' was not found.");
        }

        var packageSize =
            _packageRuleService.CalculatePackageSize(product);

        var transportType =
            _packageRuleService.GetTransportType(packageSize);

        var delivery = new Delivery
        {
            CustomerName = request.CustomerName,
            CustomerPhone = request.CustomerPhone,
            DeliveryDate = request.DeliveryDate,

            Priority = request.Priority,

            // New delivery always starts as Pending.
            Status = DeliveryStatus.Pending,

            Product = product,

            PackageSize = packageSize,
            TransportType = transportType
        };

        return await _deliveryRepository.AddAsync(
            delivery,
            cancellationToken);
    }
}