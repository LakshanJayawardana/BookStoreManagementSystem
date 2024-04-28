using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repository;

public class BookRepository : IBookRepository
{
    private ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<BooksEntity> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public void CreateBook(BooksEntity book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(BooksEntity book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }
    public BooksEntity GetBookById(int id)
    {
        return _context.Books
            .Include(b => b.Publisher)
            .FirstOrDefault(b => b.Id == id);
    }

}