namespace Backend.Domain.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal PriceBs { get; set; }
    public decimal PriceUSD { get; set; }
    public decimal ExchangeRate { get; set; }
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public ICollection<ProductOrderEntity> ProductOrders { get; set; }
}