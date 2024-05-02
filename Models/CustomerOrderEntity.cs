namespace WebApplication1.Models;
public class CustomerOrderEntity
{
    public int Id { get; set; } //Primary key
    public DateTime OrderDate {get; set;}
    public int CustomerId {get; set;} //Foreigh key
    public int ShippingMethodId {get; set;} //Foreigh key
    public int AddressId {get; set;} //Foreigh key

    public ShippingMethodEntity ShippingMethod { get; set; }
    public List<OrderLineEntity> OrderLine { get; set; }

    public List<OrderHistoryEntity> OrderHistory { get; set; }
    public CustomerEntity Customer { get; set; }

}