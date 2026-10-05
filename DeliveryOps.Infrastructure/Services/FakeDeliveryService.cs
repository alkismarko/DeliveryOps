using DeliveryOps.Application.Abstractions;
using DeliveryOps.Domain.Entities;
using DeliveryOps.Domain.Enums;

namespace DeliveryOps.Infrastructure.Services;

public class FakeDeliveryService : IDeliveryService
{
    public Task<IReadOnlyCollection<Delivery>> GetDeliveriesAsync(
        CancellationToken cancellationToken = default)
    {
        IReadOnlyCollection<Delivery> deliveries =
        [
            new Delivery
            {
                Id = 101,
                CustomerName = "Nikos Papadopoulos",
                CustomerPhone = "6911111111",
                DeliveryDate = DateTime.Today.AddDays(1),
                Status = DeliveryStatus.Pending,
                Priority = DeliveryPriority.Premium,
                WeightKg = 4.5,
                HeightCm = 40,
                WidthCm = 25,
                LengthCm = 15,
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
                WeightKg = 18,
                HeightCm = 80,
                WidthCm = 50,
                LengthCm = 40,
                PackageSize = PackageSize.Medium,
                TransportType = TransportType.Van
            },

            new Delivery
            {
                Id = 103,
                CustomerName = "George Nikolaou",
                CustomerPhone = "6933333333",
                DeliveryDate = DateTime.Today.AddDays(2),
                Status = DeliveryStatus.Pending,
                Priority = DeliveryPriority.Standard,
                WeightKg = 75,
                HeightCm = 180,
                WidthCm = 70,
                LengthCm = 65,
                PackageSize = PackageSize.Large,
                TransportType = TransportType.Truck
            }
        ];

        return Task.FromResult(deliveries);
    }
}