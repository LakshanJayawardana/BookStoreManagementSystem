namespace WebApplication1.ViewModels;

public class UpdateBookViewModel
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int? NumberOfPages { get; set; }
    public int? PublicationDate { get; set; }
    //public string ImageUrl { get; set; }
    public string? ImageUrl { get; set; }
    public int LanguageId { get; set; }
    public int PublisherId { get; set; }
    //public IFormFile ImageUrl { get; set; }
    public IFormFile Image { get; set; }
}
