namespace MyEBook.Models.DTOs
{
    public class BookDTO
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int LikeNumber { get; set; }
    }
}
