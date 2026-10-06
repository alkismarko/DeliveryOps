using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;

namespace DeliveryOps.Infrastructure.Services;

public class FakeProductCatalogService : IProductCatalogService
{
    private readonly List<Product> _products =
    [
        new Product
        {
            Code = "PR-001",
            Name = "PlayStation 5",
            WeightKg = 4.5,
            HeightCm = 39,
            WidthCm = 26,
            LengthCm = 10
        },

        new Product
        {
            Code = "PR-002",
            Name = "Refrigerator",
            WeightKg = 75,
            HeightCm = 180,
            WidthCm = 70,
            LengthCm = 65
        },

        new Product
        {
            Code = "PR-003",
            Name = "Laptop",
            WeightKg = 2,
            HeightCm = 3,
            WidthCm = 36,
            LengthCm = 25
        },

        new Product
        {
            Code = "PR-004",
            Name = "55 Inch TV",
            WeightKg = 16,
            HeightCm = 75,
            WidthCm = 125,
            LengthCm = 15
        },

        new Product
        {
            Code = "PR-005",
            Name = "Microwave",
            WeightKg = 14,
            HeightCm = 30,
            WidthCm = 50,
            LengthCm = 40
        },

        new Product
        {
            Code = "PR-006",
            Name = "Smartphone",
            WeightKg = 0.3,
            HeightCm = 18,
            WidthCm = 10,
            LengthCm = 5
        },

        new Product
        {
            Code = "PR-007",
            Name = "Washing Machine",
            WeightKg = 68,
            HeightCm = 85,
            WidthCm = 60,
            LengthCm = 60
        },

        new Product
        {
            Code = "PR-008",
            Name = "Coffee Machine",
            WeightKg = 6,
            HeightCm = 35,
            WidthCm = 25,
            LengthCm = 30
        },

        new Product
        {
            Code = "PR-009",
            Name = "Desktop PC",
            WeightKg = 12,
            HeightCm = 50,
            WidthCm = 25,
            LengthCm = 50
        },

        new Product
        {
            Code = "PR-010",
            Name = "Air Fryer",
            WeightKg = 7,
            HeightCm = 35,
            WidthCm = 32,
            LengthCm = 32
        }
    ];

    public Task<IReadOnlyCollection<Product>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyCollection<Product>>(_products);
    }

    public Task<Product?> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        var product = _products.FirstOrDefault(
            x => x.Code.Equals(
                code,
                StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(product);
    }
}