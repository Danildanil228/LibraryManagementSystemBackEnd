using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        IQueryable<Book> GetBooksByAuthor(string author);
        IQueryable<Book> GetBooksByPublisher(string publisher);
        IQueryable<Book> GetBooksByPublicationDateRange(DateTime startDate, DateTime endDate);
        IQueryable<Book> GetBooksOnDebtors();
        int GetBooksOnHand();
    }
}