using basel.Dto;
using basel.Dto.PostDtos;

namespace basel.Repo
{
    public interface IAuthorRepo
    {
        IEnumerable<Author_Dto> Get();
        Author_Dto? Get(int id);
        void Update(Author_Dto_Only Author, int id);
        void UpdateAll(Author_Dto Author, int id);
        void Delete(int id);
        void Add(Author_Dto_Only Author);
        void AddAll(Author_Dto Author);
    }
}
