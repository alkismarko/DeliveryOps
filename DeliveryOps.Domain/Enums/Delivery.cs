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

    public Product Product { get; set; } = null!;

    public PackageSize PackageSize { get; set; }

    public TransportType TransportType { get; set; }
}