using DeliveryOps.Domain.Entities;
using DeliveryOps.Domain.Enums;

namespace DeliveryOps.Domain.Services;

public class PackageRuleService
{
    public PackageSize CalculatePackageSize(Product product)
    {
        if (product.WeightKg <= 5 &&
            product.HeightCm <= 50 &&
            product.WidthCm <= 40 &&
            product.LengthCm <= 40)
        {
            return PackageSize.Small;
        }

        if (product.WeightKg <= 25 &&
            product.HeightCm <= 100 &&
            product.WidthCm <= 80 &&
            product.LengthCm <= 80)
        {
            return PackageSize.Medium;
        }

        return PackageSize.Large;
    }

    public TransportType GetTransportType(PackageSize packageSize)
    {
        return packageSize switch
        {
            PackageSize.Small => TransportType.Motorbike,
            PackageSize.Medium => TransportType.Van,
            PackageSize.Large => TransportType.Truck,

            _ => throw new ArgumentOutOfRangeException(nameof(packageSize))
        };
    }
}