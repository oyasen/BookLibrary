using basel.Data;
using basel.Dto;
using basel.Dto.PostDtos;
using basel.Models;
using Microsoft.EntityFrameworkCore;

namespace basel.Repo
{
    public class GenreRepo : IGenreRepo
    {
        private readonly ApplicationDbContext _context;
        public GenreRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Genre_Dto Genre_dto)
        {
            var Genre = new Genre
            {
                Name = Genre_dto.Name,
                Books = _context.Books.Where(x => Genre_dto.BooksId.Contains(x.Id)).ToList(),
            };
            _context.Genres.Add(Genre);
            _context.SaveChanges();
        }

        public void AddAll(Genre_Dto Genre_dto)
        {
            var Genre = new Genre
            {
                Name = Genre_dto.Name,
                Books = Genre_dto.Books.Select(x => new Book
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Authors = x.Authors.Select(x => new Author
                    {
                        Name = x.Name,
                        Phone= x.Phone,
                        Email= x.Email,
                    }).ToList(),
                }).ToList()
            };
            _context.Genres.Add(Genre);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Genre = _context.Auhtors.FirstOrDefault(x => x.Id == id);
            _context.Auhtors.Remove(Genre);
            _context.SaveChanges();
        }

        public IEnumerable<Genre_Dto_Get> Get()
        {
            var Genre = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Authors).ToList();
            return Genre.Select(x => new Genre_Dto_Get
            {
                Name = x.Name,
                Books = x.Books.Select(x => new Book_Dto_Get_Genre
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Authors = x.Authors.Select(x => new Author_Dto_Get_Only
                    { 
                        Name = x.Name,
                        Email= x.Email,
                        Phone= x.Phone,
                    }).ToList(),
                }).ToList(),
            }).ToList();
        }

        public Genre_Dto_Get? Get(int id)
        {
            var Genre = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Authors).FirstOrDefault(x => x.Id == id);

            return new Genre_Dto_Get
            {
                Name = Genre.Name,
                Books = Genre.Books.Select(x => new Book_Dto_Get_Genre
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Authors = x.Authors.Select(x => new Author_Dto_Get_Only
                    { 
                        Name = x.Name,
                        Email = x.Email,
                        Phone = x.Phone,
                    }).ToList(),
                }).ToList(),
            };
        }

        public void Update(Genre_Dto Genre_dto, int id)
        {
            var Genre = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Authors).FirstOrDefault(x => x.Id == id);

            Genre.Name = Genre_dto.Name;
            Genre.Books = _context.Books.Where(x => Genre_dto.BooksId.Contains(x.Id)).ToList();
            _context.Auhtors.Add(Genre);
            _context.SaveChanges();
        }

        public void UpdateAll(Genre_Dto Genre_dto, int id)
        {
            var Genre = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Authors).FirstOrDefault(x => x.Id == id);

            Genre.Name = Genre_dto.Name;
            Genre.Books = Genre_dto.Books.Select(x => new Book
            {
                Title = x.Title,
                PublishedDate = x.PublishedDate,
                Authors = x.Authors.Select(x => new Author
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    Email = x.Email,
                }).ToList(),
            }).ToList();

            _context.Auhtors.Add(Genre);
            _context.SaveChanges();
        }
    }
}
