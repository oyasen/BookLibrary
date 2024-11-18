using basel.Dto;

namespace basel.Repo
{
    public interface IBookRepo
    {
        IEnumerable<Book_Dto> Get();
        Book_Dto? Get(int id);
        void Update(Book_Dto book_dto,int id);
        void UpdateAll(Book_Dto book_dto,int id);
        void Delete(int id);
        void Add(Book_Dto book_dto);
        void AddAll(Book_Dto book_dto);
    }
}
