namespace basel.Dto
{
    public class Book_Dto_Get_Genre
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public List<Author_Dto_Get_Only>? Authors { get; set; } = new List<Author_Dto_Get_Only>();
    }
}
