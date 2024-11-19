using basel.Models;

namespace basel.Dto.GetDtos
{
    public class Card_Get
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ExpDate { get; set; }
        public Author_Dto_Get Author { get; set; }
    }
}
