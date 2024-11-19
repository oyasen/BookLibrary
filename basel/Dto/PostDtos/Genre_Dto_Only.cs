namespace basel.Dto.PostDtos
{
    public class Genre_Dto_Only
    {
        public string Name { get; set; } = default!;
        public ICollection<int>? BooksId { get; set; }
    }
}
