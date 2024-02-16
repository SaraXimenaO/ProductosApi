namespace Products.Domain.Entities;

public class DiscountResponse
{
    public string ProductId { get; set; }
    public int Discount { get; set; } = 0;
}
