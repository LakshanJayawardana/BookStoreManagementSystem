namespace WebApplication1.Models;
public class OrderLineEntity
{
    public int Id { get; set; } //Primary key
    public int OrderId {get; set;} //Foreigh key
    public int BookId {get; set;} //Foreigh key
    public int Price {get; set;}
    public BooksEntity Book { get; set; }
    public CustomerOrderEntity CustomerOrder { get; set; }


}