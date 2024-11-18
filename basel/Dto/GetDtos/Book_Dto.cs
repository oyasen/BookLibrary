namespace basel.Dto
{
    public class Book_Dto_Get
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public List<Author_Dto_Get_Only>? Authors { get; set; } = new List<Author_Dto_Get_Only>();
        public List<Genre_Dto_Get_Only>? Genres { get; set; } = new List<Genre_Dto_Get_Only>();
    }
}
