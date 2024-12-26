using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using System.Threading.Tasks;

namespace LibraryManagementSystem.GraphQL
{
    public class Mutation
    {
        public async Task<Book> AddBook([Service] IBookRepository bookRepository, BookInput bookInput)
        {
            var book = new Book
            {
                Title = bookInput.Title,
                Author = bookInput.Author,
                Publisher = bookInput.Publisher,
                PublicationDate = bookInput.PublicationDate,
                Location = bookInput.Location,
                IsAvailable = bookInput.IsAvailable,
                DueDate = bookInput.DueDate,
                ReaderId = bookInput.ReaderId
            };

            return await bookRepository.AddBook(book);
        }

        public async Task<Book> UpdateBook([Service] IBookRepository bookRepository, int id, BookInput bookInput)
        {
            var book = await bookRepository.GetBookById(id);
            if (book == null)
            {
                throw new Exception($"Book with id {id} not found.");
            }

            book.Title = bookInput.Title ?? book.Title;
            book.Author = bookInput.Author ?? book.Author;
            book.Publisher = bookInput.Publisher ?? book.Publisher;
            book.PublicationDate = bookInput.PublicationDate;
            book.Location = bookInput.Location ?? book.Location;
            book.IsAvailable = bookInput.IsAvailable;
            book.DueDate = bookInput.DueDate;
            book.ReaderId = bookInput.ReaderId;

            return await bookRepository.UpdateBook(book);
        }

        public async Task<bool> DeleteBook([Service] IBookRepository bookRepository, int id)
        {
            return await bookRepository.DeleteBook(id);
        }

        public async Task<Reader> AddReader([Service] IReaderRepository readerRepository, ReaderInput readerInput)
        {
            var reader = new Reader
            {
                Name = readerInput.Name,
                ContactInfo = readerInput.ContactInfo
            };

            return await readerRepository.AddReader(reader);
        }

        public async Task<Reader> UpdateReader([Service] IReaderRepository readerRepository, int id, ReaderInput readerInput)
        {
            var reader = await readerRepository.GetReaderById(id);
            if (reader == null)
            {
                throw new Exception($"Reader with id {id} not found.");
            }

            reader.Name = readerInput.Name ?? reader.Name;
            reader.ContactInfo = readerInput.ContactInfo ?? reader.ContactInfo;

            return await readerRepository.UpdateReader(reader);
        }

        public async Task<bool> DeleteReader([Service] IReaderRepository readerRepository, int id)
        {
            return await readerRepository.DeleteReader(id);
        }
    }

    public class BookInput
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Location { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ReaderId { get; set; }
    }

    public class ReaderInput
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    }
}