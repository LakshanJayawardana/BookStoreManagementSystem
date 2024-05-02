namespace WebApplication1.Models;
public class OrderHistoryEntity
{
    public int Id { get; set; } //Primary key
    public int OrderId {get; set;} //Foreigh key
    public int StatusId {get; set;} //Foreigh key
    public DateTime StatusDate {get; set;}

    public OrderStatusEntity OrderStatus { get; set; }
    public CustomerOrderEntity CustomerOrder { get; set; }

}