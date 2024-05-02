using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;

public class CustomerEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public AppUserEntity AppUser { get; set; }
    public List<CustomerOrderEntity> CustomerOrder { get; set; }

}