using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IReaderRepository
    {
        IQueryable<Reader> GetAllReaders();
        Task<Reader> GetReaderById(int id);
        Task<Reader> AddReader(Reader reader);
        Task<Reader> UpdateReader(Reader reader);
        Task<bool> DeleteReader(int id);
        IQueryable<Reader> GetDebtors();
        int GetBooksOnHandByReaderId(int readerId);
    }
}