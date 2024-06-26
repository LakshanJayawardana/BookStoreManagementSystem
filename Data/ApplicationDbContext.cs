using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;
public class ApplicationDbContext : IdentityDbContext<AppUserEntity>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<BooksEntity> Books { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookAuthorEntity> BookAuthors { get; set; }
    public DbSet<PublisherEntity> Publishers { get; set; }
    public DbSet<LanguageEntity> Languages { get; set; }
    public DbSet<OrderLineEntity> OrderLines { get; set; }
    public DbSet<CustomerOrderEntity> CustomerOrders { get; set; }
    public DbSet<ShippingMethodEntity> ShippingMethods { get; set; }
    public DbSet<OrderHistoryEntity> OrderHistories { get; set; }
    public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BookAuthorEntity>().HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookAuthorEntity>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthorEntity>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);

    }
}

