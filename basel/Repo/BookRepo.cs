using basel.Data;
using basel.Dto;
using basel.Dto.PostDtos;
using basel.Models;
using Microsoft.EntityFrameworkCore;

namespace basel.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext _context;
        public BookRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Book_Dto_Only book_dto)
        {
            var book = new Book
            {
                Title = book_dto.Title,
                PublishedDate = book_dto.PublishedDate,
                Authors = _context.Auhtors.Where(x => book_dto.AuthorsId.Contains(x.Id)).ToList(),
                Genres = _context.Genres.Where(x=> book_dto.GenresId.Contains(x.Id)).ToList()
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        
        public void AddAll(Book_Dto book_dto)
        {
            var book = new Book
            {
                Title = book_dto.Title,
                PublishedDate = book_dto.PublishedDate,
                Authors = book_dto.Authors.Select(x => new Author
                {
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                }).ToList(),
                Genres = book_dto.Genres.Select(x => new Genre
                {
                    Name = x.Name,
                }).ToList()
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Include(b => b.Genres).Include(b => b.Authors).FirstOrDefault(x => x.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book_Dto> Get()
        {
            var book = _context.Books.Include(b=> b.Genres).Include(b=>b.Authors).ToList();

            return book.Select(x=> new Book_Dto
            {
                Title = x.Title,
                PublishedDate = x.PublishedDate,
                Authors = x.Authors.Select(y => new Author_Dto_Get_Only
                {
                    Email = y.Email,
                    Name = y.Name,
                    Phone = y.Phone,
                }).ToList(),
                Genres = x.Genres.Select(y => new Genre_Dto_Get_Only
                {
                    Name = y.Name,
                }).ToList()
            }).ToList();
        }

        public Book_Dto? Get(int id)
        {
            var book = _context.Books.Include(b => b.Genres).Include(b => b.Authors).FirstOrDefault(x => x.Id == id);

            return new Book_Dto{
                Title = book.Title ,
                PublishedDate= book.PublishedDate,
                Authors = book.Authors.Select(x=> new Author_Dto_Get_Only
                {
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                }).ToList(),
                Genres = book.Authors.Select(x=> new Genre_Dto_Get_Only
                {
                    Name = x.Name,
                }).ToList()
            };
        }

        public void Update(Book_Dto_Only book_dto, int id)
        {
            var book = _context.Books.Include(b => b.Genres).Include(b => b.Authors).FirstOrDefault(x => x.Id == id);
            book.Title = book_dto.Title;
            book.PublishedDate = book_dto.PublishedDate;
            book.Authors = _context.Auhtors.Where(x => book_dto.AuthorsId.Contains(x.Id)).ToList();
            book.Genres = _context.Genres.Where(x => book_dto.GenresId.Contains(x.Id)).ToList();
            _context.Books.Update(book);
            _context.SaveChanges(); 
        }

        public void UpdateAll(Book_Dto book_dto, int id)
        {
            var book = _context.Books.Include(b => b.Genres).Include(b => b.Authors).FirstOrDefault(x => x.Id == id);
            book.Title = book_dto.Title;
            book.PublishedDate = book_dto.PublishedDate;
            book.Authors = _context.Auhtors.Select(x => new Author
            {
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
            }).ToList();
            book.Genres = _context.Genres.Select(x => new Genre
            {
                Name = x.Name,
            }).ToList();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
