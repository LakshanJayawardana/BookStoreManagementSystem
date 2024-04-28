namespace WebApplication1.Models
{
    public class LanguageEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<BooksEntity> Books { get; set; }
    }
}