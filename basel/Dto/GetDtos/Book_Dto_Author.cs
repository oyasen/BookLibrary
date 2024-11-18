namespace basel.Dto
{
    public class Book_Dto_Get_Author
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public List<Genre_Dto_Get>? Genres { get; set; } = new List<Genre_Dto_Get>();
    }
}
