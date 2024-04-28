namespace WebApplication1.Models;
public class OrderLineEntity
{
    public int OrderLineId { get; set; } //Primary key
    public int OrderId {get; set;} //Foreigh key
    public int BookId {get; set;} //Foreigh key
    public int Price {get; set;}

}