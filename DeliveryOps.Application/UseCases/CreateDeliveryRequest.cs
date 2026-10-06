using DeliveryOps.Domain.Enums;

namespace DeliveryOps.Application.UseCases;

public class CreateDeliveryRequest
{
    public string ProductCode { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;

    public DateTime DeliveryDate { get; set; }

    public DeliveryPriority Priority { get; set; }
}