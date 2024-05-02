namespace WebApplication1.Models;
public class OrderStatusEntity
{
    public int Id { get; set; } //Primary key
    public string StatusValue {get; set;}
    public List<OrderHistoryEntity> OrderHistories { get; set; }
}