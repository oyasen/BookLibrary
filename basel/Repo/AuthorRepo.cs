using basel.Data;
using basel.Dto;
using basel.Dto.PostDtos;
using basel.Models;
using Microsoft.EntityFrameworkCore;

namespace basel.Repo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Author_Dto_Only Author_dto)
        {
            var Author = new Author
            {
                Name = Author_dto.Name,
                Email = Author_dto.Email,
                Phone = Author_dto.Phone,
                Books = _context.Books.Where(x=> Author_dto.BooksId.Contains(x.Id)).ToList(),
            };
            _context.Auhtors.Add(Author);
            _context.SaveChanges();
        }

        public void AddAll(Author_Dto Author_dto)
        {
            var Author = new Author
            {
                Name = Author_dto.Name,
                Email = Author_dto.Email,
                Phone = Author_dto.Phone,
                Books = Author_dto.Books.Select(x => new Book
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Genres = x.Genres.Select(x => new Genre
                    {
                        Name = x.Name,
                    }).ToList(),
                }).ToList()
            };
            _context.Auhtors.Add(Author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Author = _context.Auhtors.FirstOrDefault(x => x.Id == id);
            _context.Auhtors.Remove(Author);
            _context.SaveChanges();
        }

        public IEnumerable<Author_Dto> Get()
        {
            var Author = _context.Auhtors.Include(x=>x.Books).ThenInclude(x=>x.Genres).ToList();

            return Author.Select(x => new Author_Dto
            {
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Books = x.Books.Select(x => new Book_Dto_Get_Author { 
                    Title = x.Title,
                    PublishedDate= x.PublishedDate,
                    Genres = x.Genres.Select(x=>new Genre_Dto_Get_Only { Name = x.Name }).ToList(),
                }).ToList(),
            }).ToList();
        }

        public Author_Dto? Get(int id)
        {
            var Author = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Genres).FirstOrDefault(x=>x.Id == id);

            return new Author_Dto
            {
                Name = Author.Name,
                Email = Author.Email,
                Phone = Author.Phone,
                Books = Author.Books.Select(x => new Book_Dto_Get_Author
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Genres = x.Genres.Select(x => new Genre_Dto_Get_Only { Name = x.Name }).ToList(),
                }).ToList(),
            };
        }

        public void Update(Author_Dto_Only Author_dto, int id)
        {
            var Author = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Genres).FirstOrDefault(x => x.Id == id);

            Author.Name = Author_dto.Name;
            Author.Email = Author_dto.Email;
            Author.Phone = Author_dto.Phone;
            Author.Books = _context.Books.Where(x => Author_dto.BooksId.Contains(x.Id)).ToList();
            _context.Auhtors.Update(Author);
            _context.SaveChanges();
        }

        public void UpdateAll(Author_Dto Author_dto, int id)
        {
            var Author = _context.Auhtors.Include(x => x.Books).ThenInclude(x => x.Genres).FirstOrDefault(x => x.Id == id);

            Author.Name = Author_dto.Name;
            Author.Email = Author_dto.Email;
            Author.Phone = Author_dto.Phone;
            Author.Books = Author_dto.Books.Select(x => new Book
            {
                Title = x.Title,
                PublishedDate = x.PublishedDate,
                Genres = x.Genres.Select(x => new Genre
                {
                    Name = x.Name,
                }).ToList(),
            }).ToList();
            
            _context.Auhtors.Update(Author);
            _context.SaveChanges();
        }
    }
}
