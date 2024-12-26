using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryDbContext _context;

        public ReaderRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Reader> GetAllReaders()
        {
            return _context.Readers.AsQueryable();
        }

        public async Task<Reader> GetReaderById(int id)
        {
            return await _context.Readers
                .Include(r => r.BorrowedBooks)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reader> AddReader(Reader reader)
        {
            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task<Reader> UpdateReader(Reader reader)
        {
            _context.Entry(reader).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task<bool> DeleteReader(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<Reader> GetDebtors()
        {
            return _context.Readers
                .Where(r => r.BorrowedBooks.Any(b => b.DueDate < DateTime.Now));
        }
        public int GetBooksOnHandByReaderId(int readerId)
        {
            return _context.Books.Count(b => b.ReaderId == readerId && !b.IsAvailable);
        }
    }
}