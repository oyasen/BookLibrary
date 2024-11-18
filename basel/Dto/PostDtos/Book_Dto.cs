namespace basel.Dto.PostDtos
{
    public class Book_Dto
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public List<int>? AuthorsId { get; set; } = new List<int>();
        public List<int>? GenresId { get; set; } = new List<int>();
        public List<Author_Dto>? Authors { get; set; } = new List<Author_Dto>();
        public List<Genre_Dto>? Genres { get; set; } = new List<Genre_Dto>();
    }
}
