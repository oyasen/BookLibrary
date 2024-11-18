namespace basel.Dto
{
    public class Author_Dto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public ICollection<Book_Dto>? Books { get; set; }
        public ICollection<int>? BooksId { get; set; }
    }
}
