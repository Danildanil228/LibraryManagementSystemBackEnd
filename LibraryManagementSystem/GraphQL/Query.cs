using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks([Service] IBookRepository bookRepository)
    {
        return bookRepository.GetAllBooks();
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Reader> GetReaders([Service] IReaderRepository readerRepository)
    {
        return readerRepository.GetAllReaders();
    }


    public async Task<Reader> GetReaderById([Service] IReaderRepository readerRepository, int id)
    {
        return await readerRepository.GetReaderById(id);
    }

    public async Task<Book> GetBookById([Service] IBookRepository bookRepository, int id)
    {
        return await bookRepository.GetBookById(id);
    }

    public IQueryable<Reader> GetDebtors([Service] IReaderRepository readerRepository)
    {
        return readerRepository.GetDebtors();
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooksByAuthor([Service] IBookRepository bookRepository, string author)
    {
        return bookRepository.GetBooksByAuthor(author);
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooksByPublisher([Service] IBookRepository bookRepository, string publisher)
    {
        return bookRepository.GetBooksByPublisher(publisher);
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooksByPublicationDateRange([Service] IBookRepository bookRepository, DateTime startDate, DateTime endDate)
    {
        return bookRepository.GetBooksByPublicationDateRange(startDate, endDate);
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooksOnDebtors([Service] IBookRepository bookRepository)
    {
        return bookRepository.GetBooksOnDebtors();
    }
    public int GetBooksOnHand([Service] IBookRepository bookRepository)
    {
        return bookRepository.GetBooksOnHand();
    }
    public int GetBooksOnHandByReaderId([Service] IReaderRepository readerRepository, int readerId)
    {
        return readerRepository.GetBooksOnHandByReaderId(readerId);
    }

}