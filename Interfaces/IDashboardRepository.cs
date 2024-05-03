namespace WebApplication1.Interfaces;
using WebApplication1.Models;

public interface IDashBoardRepository
{
    Task<AppUser> GetUserById(string id);
    Task<AppUser> GetByIdNoTracking(string id);
    IEnumerable<BooksEntity> GetAllBooks();
    void UpdateBook(BooksEntity book);

}