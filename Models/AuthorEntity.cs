namespace WebApplication1.Models;
public class AuthorEntity
{
    public int Id { get; set; }
    public string? AuthorName { get; set; }

    public virtual ICollection<BookAuthorEntity> BookAuthors { get; set; }

}