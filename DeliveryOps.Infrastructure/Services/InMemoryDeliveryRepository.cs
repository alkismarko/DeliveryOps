using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;
using DeliveryOps.Domain.Enums;

namespace DeliveryOps.Infrastructure.Services;

public class InMemoryDeliveryRepository : IDeliveryRepository
{
    private readonly List<Delivery> _deliveries =
    [
        new Delivery
        {
            Id = 101,
            CustomerName = "Nikos Papadopoulos",
            CustomerPhone = "6911111111",
            DeliveryDate = DateTime.Today.AddDays(1),
            Status = DeliveryStatus.Pending,
            Priority = DeliveryPriority.Premium,

            Product = new Product
            {
                Code = "PR-001",
                Name = "PlayStation 5",
                WeightKg = 4.5,
                HeightCm = 39,
                WidthCm = 26,
                LengthCm = 10
            },

            PackageSize = PackageSize.Small,
            TransportType = TransportType.Motorbike
        },

        new Delivery
        {
            Id = 102,
            CustomerName = "Maria Georgiou",
            CustomerPhone = "6922222222",
            DeliveryDate = DateTime.Today.AddDays(1),
            Status = DeliveryStatus.OnTheWay,
            Priority = DeliveryPriority.Standard,

            Product = new Product
            {
                Code = "PR-002",
                Name = "Refrigerator",
                WeightKg = 75,
                HeightCm = 180,
                WidthCm = 70,
                LengthCm = 65
            },

            PackageSize = PackageSize.Large,
            TransportType = TransportType.Truck
        }
    ];

    public Task<IReadOnlyCollection<Delivery>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyCollection<Delivery>>(
            _deliveries.ToList());
    }

    public Task<Delivery> AddAsync(
        Delivery delivery,
        CancellationToken cancellationToken = default)
    {
        var nextId = _deliveries.Count == 0
            ? 1
            : _deliveries.Max(x => x.Id) + 1;

        delivery.Id = nextId;

        _deliveries.Add(delivery);

        return Task.FromResult(delivery);
    }
}