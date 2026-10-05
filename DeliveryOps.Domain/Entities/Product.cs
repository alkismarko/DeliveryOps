namespace DeliveryOps.Domain.Entities;

public class Product
{
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public double WeightKg { get; set; }

    public double HeightCm { get; set; }

    public double WidthCm { get; set; }

    public double LengthCm { get; set; }
}