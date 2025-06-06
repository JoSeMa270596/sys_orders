namespace Backend.Domain.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public DateTime DateOrder { get; set; }
    public decimal TotalBs { get; set; }
    public decimal TotalUSD { get; set; }
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public ICollection<ProductOrderEntity> ProductOrders { get; set; }
}