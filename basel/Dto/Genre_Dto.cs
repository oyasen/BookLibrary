namespace basel.Dto
{
    public class Genre_Dto
    {
        public string Name { get; set; } = default!;
        public ICollection<Book_Dto>? Books { get; set; }
        public ICollection<int>? BooksId { get; set; }
    }
}
