using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyEBook.Models;
using MyEBook.Models.DTOs;
using MyEBook.Models.Entities;

namespace MyEBook.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly EBookDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(EBookDbContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDTO> AddBookAsync(BookDTO bookDTO)
        {
            var newBook = _mapper.Map<Book>(bookDTO);
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return bookDTO;
        }

        public async Task DeleteBookAsync(Guid Id)
        {
            var deleteBook = _context.Books.SingleOrDefault(book => book.Id == Id);

            if (deleteBook != null)
            {
                _context.Books.Remove(deleteBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> UpdateBookAsync(Guid Id, BookDTO bookDTO)
        {
            if (Id == bookDTO.Id)
            {
                var updateBook = _mapper.Map<Book>(bookDTO);
                _context.Books.Update(updateBook);
                await _context.SaveChangesAsync();
            }

            return bookDTO;
        }
    }
}
