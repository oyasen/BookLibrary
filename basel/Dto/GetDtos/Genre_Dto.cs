namespace basel.Dto
{
    public class Genre_Dto_Get
    {
        public string Name { get; set; } = default!;
        public ICollection<Book_Dto_Get_Genre>? Books { get; set; }
    }
}
