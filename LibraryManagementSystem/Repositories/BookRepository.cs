using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _context.Books.AsQueryable();
        }
        public int GetBooksOnHand()
        {
            return _context.Books.Count(b => !b.IsAvailable);
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                throw new Exception($"Book with id {id} not found.");
            }

            return book;
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author == author);
        }

        public IQueryable<Book> GetBooksByPublisher(string publisher)
        {
            return _context.Books.Where(b => b.Publisher == publisher);
        }

        public IQueryable<Book> GetBooksByPublicationDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Books.Where(b => b.PublicationDate >= startDate && b.PublicationDate <= endDate);
        }

        public IQueryable<Book> GetBooksOnDebtors()
        {
            return _context.Books.Where(b => !b.IsAvailable && b.DueDate < DateTime.Now);
        }

    }
}