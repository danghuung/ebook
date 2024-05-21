using MyEBook.Models.DTOs;

namespace MyEBook.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookDTO>> GetAllBooksAsync();
        public Task<BookDTO> GetBookAsync(Guid id);
        public Task<BookDTO> AddBookAsync(BookDTO bookDTO);
        public Task<BookDTO> UpdateBookAsync(Guid Id, BookDTO bookDTO);

        public Task DeleteBookAsync(Guid Id);
    }
}
