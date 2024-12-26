using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    using Bogus;
    using LibraryManagementSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DataSeeder
    {
        public static void SeedData(LibraryDbContext context)
        {
            if (!context.Readers.Any())
            {
                var readerFaker = new Faker<Reader>()
                    .RuleFor(r => r.Name, f => f.Name.FullName())
                    .RuleFor(r => r.ContactInfo, f => f.Internet.Email());

                var readers = readerFaker.Generate(10);
                context.Readers.AddRange(readers);
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var bookFaker = new Faker<Book>()
                    .RuleFor(b => b.Title, f => f.Lorem.Sentence())
                    .RuleFor(b => b.Author, f => f.Name.FullName())
                    .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
                    .RuleFor(b => b.PublicationDate, f => f.Date.Past(10))
                    .RuleFor(b => b.Location, f => $"Shelf {f.Random.Number(1, 10)}")
                    .RuleFor(b => b.IsAvailable, f => f.Random.Bool())
                    .RuleFor(b => b.DueDate, (f, b) => b.IsAvailable ? null : f.Date.Future())
                    .RuleFor(b => b.ReaderId, (f, b) => b.IsAvailable ? null : f.PickRandom(context.Readers.Select(r => r.Id).ToList()));

                var books = bookFaker.Generate(50);
                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}