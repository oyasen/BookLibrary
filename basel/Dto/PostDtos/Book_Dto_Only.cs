namespace basel.Dto.PostDtos
{
    public class Book_Dto_Only
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public List<int>? AuthorsId { get; set; } = new List<int>();
        public List<int>? GenresId { get; set; } = new List<int>();
    }
}
