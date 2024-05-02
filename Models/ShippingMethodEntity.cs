namespace WebApplication1.Models;
public class ShippingMethodEntity
{
    public int Id { get; set; } //Primary key
    public string MethodName {get; set;}
    public int Cost {get; set;}
    public List<CustomerOrderEntity> CustomerOrder { get; set; }

}