using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repository;

public class DashboardRepository : IDashboardRepository
{
    private ApplicationDbContext _context;
    private IHttpContextAccessor _httpContextAccessor;
    public DashboardRepository(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public IEnumerable<CustomerEntity> GetAllBooks()
    {
        var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
        var user = _context.Customers.Where(x => x.UserId == curUser);
        return user.ToList();
    }



}