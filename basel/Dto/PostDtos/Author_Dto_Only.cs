namespace basel.Dto.PostDtos
{
    public class Author_Dto_Only
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public ICollection<int>? BooksId { get; set; }
    }
}
