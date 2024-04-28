namespace WebApplication1.Models;

public class BooksEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    //public int LanguageId { get; set; }
    public int? NumberOfPages { get; set; }
    public int? PublicationDate { get; set; }
    public string? ImageUrl { get; set; }
    //public int PublisherId { get; set; }
    //public List<AuthorEntity> Authors { get; set; }
    public int PublisherId { get; set; }

    public PublisherEntity Publisher { get; set; }
    public int LanguageId { get; set; }
    public LanguageEntity Language { get; set; }

    public virtual ICollection<BookAuthorEntity>BookAuthors { get; set; }
    //public List<OrderLineEntity> OrderLine { get; set; }
}