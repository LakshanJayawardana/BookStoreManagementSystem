using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

public class PublisherController : Controller
{
    private ApplicationDbContext _context;
    public PublisherController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var publisher = _context.Publishers.ToList();
        return View(publisher);
    }
}
