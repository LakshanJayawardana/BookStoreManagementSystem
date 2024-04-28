using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

public class AuthorController : Controller
{
    private ApplicationDbContext _context;
    public AuthorController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var authors = _context.Authors.ToList();
        return View(authors);
    }
    public IActionResult Detail(int id)
    {
        var authorDetail = _context.Authors.FirstOrDefault(a => a.Id == id);
        if (authorDetail == null)
        {
            return NotFound(); // Or handle the case where authorDetail is null
        }
        return View(authorDetail);
    }

}
