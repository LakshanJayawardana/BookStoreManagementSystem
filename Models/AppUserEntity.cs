using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace WebApplication1.Models;

public class AppUserEntity : IdentityUser
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public ICollection<CustomerEntity> Customer { get; set; }
    
}