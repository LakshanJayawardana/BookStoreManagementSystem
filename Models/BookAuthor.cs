using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;
public class BookAuthorEntity
{
    public int BookId { get; set; }
    public BooksEntity Book { get; set; }
    public int AuthorId { get; set; }
    public AuthorEntity Author { get; set; }
}