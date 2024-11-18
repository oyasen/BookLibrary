namespace basel.Dto
{
    public class Book_Dto_Get
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public List<Author_Dto_Get>? Authors { get; set; } = new List<Author_Dto_Get>();
        public List<Genre_Dto_Get>? Genres { get; set; } = new List<Genre_Dto_Get>();
    }
}
