namespace basel.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
