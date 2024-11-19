using basel.Dto;
using basel.Dto.PostDtos;

namespace basel.Repo
{
    public interface IGenreRepo
    {
        IEnumerable<Genre_Dto_Get> Get();
        Genre_Dto_Get? Get(int id);
        void Update(Genre_Dto_Only Genre, int id);
        void UpdateAll(Genre_Dto Genre, int id);
        void Delete(int id);
        void Add(Genre_Dto_Only Genre);
        void AddAll(Genre_Dto Genre);
    };
}
