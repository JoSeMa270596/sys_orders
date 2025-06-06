namespace Backend.Domain.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<ProductEntity> Products { get; set; }
    public ICollection<OrderEntity> Orders { get; set; }
}