using basel.Dto;

namespace basel.Repo
{
    public interface IAuthorRepo
    {
        IEnumerable<Author_Dto> Get();
        Author_Dto? Get(int id);
        void Update(Author_Dto Author, int id);
        void UpdateAll(Author_Dto Author, int id);
        void Delete(int id);
        void Add(Author_Dto Author);
        void AddAll(Author_Dto Author);
    }
}
