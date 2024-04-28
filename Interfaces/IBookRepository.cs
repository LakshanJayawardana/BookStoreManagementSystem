namespace WebApplication1.Interfaces;
using WebApplication1.Models;

public interface IBookRepository
{
    IEnumerable<BooksEntity> GetAllBooks();
    void CreateBook(BooksEntity book);
    void UpdateBook(BooksEntity book);
    BooksEntity GetBookById(int id);
    //void DeleteBook(int id);
}