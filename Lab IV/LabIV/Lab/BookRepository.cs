using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using Lab;

namespace LabIV
{
    public class BookRepository
    {
        private readonly IEnumerable<Book> bookRepo;


        public BookRepository(IEnumerable<Book> books)
        {
            EnsureArg.IsNotNull(books);
            bookRepo = books;
        }


        //Query syntax
        public IEnumerable<Book> RetriveAllBooksSQ()
        {
            var query = from Book in bookRepo select Book;
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByYearDescendingSQ()
        {
            var query = from Book in bookRepo orderby Book.Year descending select Book;
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByYearAscendingSQ()
        {
            var query = from Book in bookRepo orderby Book.Year select Book;
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByPriceAscendingSQ()
        {
            var query = from Book in bookRepo orderby Book.Price select Book;
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByPriceDescendingSQ()
        {
            var query = from Book in bookRepo orderby Book.Price descending select Book;
            return query;
        }

        public Dictionary<string, List<Book>> RetriveAllBooksGroupedByGenreSQ()
        {
            var query = from Book in bookRepo
                group Book by Book.Genre
                into D
                select new {Genre = D.Key, MyBook = D.ToList()};
            return query.ToDictionary(D => D.Genre, D => D.MyBook);
        }


        // syntaxmethods
        public IEnumerable<Book> RetriveAllBooksSM()
        {
            var query = bookRepo.Select(Book => Book);
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByYearDescendingSM()
        {
            var query = bookRepo.OrderByDescending(Book => Book.Year).Select(Book => Book);
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByYearAscendingSM()
        {
            var query = bookRepo.OrderBy(Book => Book.Year).Select(Book => Book);
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByPriceAscendingSM()
        {
            var query = bookRepo.OrderBy(Book => Book.Price).Select(Book => Book);
            return query;
        }

        public IEnumerable<Book> RetriveAllOrderByPriceDescendingSM()
        {
            var query = bookRepo.OrderByDescending(Book => Book.Price).Select(Book => Book);
            
            return query;
        }

        public Dictionary<string, List<Book>> RetriveAllBooksGroupedByGenreSM()
        {
            var query = bookRepo.GroupBy(Book => Book.Genre).Select(D => new {Genre = D.Key, MyBook = D.ToList()});
            return query.ToDictionary(D => D.Genre, D => D.MyBook);
        }
    }
}