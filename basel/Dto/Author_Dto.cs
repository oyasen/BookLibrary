namespace basel.Dto
{
    public class Author_Dto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public ICollection<Book_Dto_Get_Author>? Books { get; set; }
    }
}
