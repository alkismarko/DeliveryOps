using DeliveryOps.Domain.Enums;

namespace DeliveryOps.Domain.Entities;

public class Delivery
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerPhone { get; set; } = string.Empty;

    public DateTime DeliveryDate { get; set; }

    public DeliveryStatus Status { get; set; }

    public DeliveryPriority Priority { get; set; }

    public double WeightKg { get; set; }

    public double HeightCm { get; set; }

    public double WidthCm { get; set; }

    public double LengthCm { get; set; }

    public PackageSize PackageSize { get; set; }

    public TransportType TransportType { get; set; }
}