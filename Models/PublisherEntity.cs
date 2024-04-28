namespace WebApplication1.Models;
public class PublisherEntity
{
    public int Id { get; set; }
    public string? PublisherName { get; set; }
    public List<BooksEntity> Books { get; set; }
}