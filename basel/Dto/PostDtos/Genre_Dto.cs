﻿namespace basel.Dto.PostDtos
{
    public class Genre_Dto
    {
        public string Name { get; set; } = default!;
        public ICollection<Book_Dto_Get_Genre>? Books { get; set; }
    }
}
