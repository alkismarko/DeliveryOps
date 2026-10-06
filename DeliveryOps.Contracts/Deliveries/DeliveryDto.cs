namespace DeliveryOps.Contracts.Deliveries;

public class DeliveryDto
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerPhone { get; set; } = string.Empty;

    public DateTime DeliveryDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public string ProductCode { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public string PackageSize { get; set; } = string.Empty;

    public string TransportType { get; set; } = string.Empty;
}