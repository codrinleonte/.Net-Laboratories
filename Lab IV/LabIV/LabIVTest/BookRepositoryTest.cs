using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Lab;
using LabIProject.Test;
using LabIV;
using Xunit;

namespace LabTest
{
    public class BookRepositoryTest : BaseTest<BookRepository>
    {
        private readonly IEnumerable<Book> booksRepoMock = new List<Book>
        {
            Book.Create("Carte De Colorat", 2012, 20, "Carte pentru copii"),
            Book.Create("Codul Lui Da Vinci", 2010, 30, "Mister"),
            Book.Create("Robinson Crusoe", 1998, 20, "Aventura"),
            Book.Create("lala", 2015, 20, "Carte pentru copii"),
            Book.Create("haha", 2010, 30, "Mister"),
            Book.Create("Capra cu 2 Iezi", 1998, 20, "Aventura"),
            Book.Create("Alba ca Neagra", 2011, 21, "Carte pentru copii"),
            Book.Create("Cenusareasa", 2010, 32, "Mister"),
            Book.Create("Harap Alb", 1997, 20, "Aventura"),
            Book.Create("Ultima noapte de Razboi, Intaia Noapte de Dragost", 1940, 20, "Carte pentru copii")
        };

        protected override BookRepository SetupSystemUnderTest()
        {
            return new BookRepository(booksRepoMock);
        }


        [Fact]
        public void Given_RetrieveAllBooksSM_When_GoodRepoIsPassed_Then_ShouldReturnAllBooks()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllBooksSM());
            result.Should().Equal(booksRepoMock);
        }


        [Fact]
        public void Given_RetrieveAllBooksSQ_When_GoodRepoIsPassed_Then_ShouldReturnAllBooks()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllBooksSQ());
            result.Should().Equal(booksRepoMock);
        }

        [Fact]
        public void Given_RetriveAllBooksGroupedByGenreSM_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new Dictionary<string, List<Book>>(SystemUnderTest.RetriveAllBooksGroupedByGenreSM());
            var newBookList = new List<Book>
            {
                Book.Create("Robinson Crusoe", 1998, 20, "Aventura"),
                Book.Create("lala", 2015, 20, "Carte pentru copii"),
                Book.Create("haha", 2010, 30, "Mister"),
                Book.Create("Capra cu 2 Iezi", 1998, 20, "Aventura")
            };

            var query = booksRepoMock.GroupBy(Book => Book.Genre).Select(D => new {Genre = D.Key, MyBook = D.ToList()});
            result.Should().NotEqual(query.ToDictionary(D => D.Genre, D => D.MyBook));
        }

        [Fact]
        public void Given_RetriveAllBooksGroupedByGenreSM_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var a = booksRepoMock.GroupBy(Book => Book.Genre).Select(D => new {Genre = D.Key, MyBook = D.ToList()});

            var query = a.ToDictionary(D => D.Genre, D => D.MyBook);

            SetupSystemUnderTest().RetriveAllBooksGroupedByGenreSM().Should().Equals(query);
        }

        [Fact]
        public void Given_RetriveAllBooksGroupedByGenreSQ_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new Dictionary<string, List<Book>>(SystemUnderTest.RetriveAllBooksGroupedByGenreSQ());
            var newBookList = new List<Book>
            {
                Book.Create("Robinson Crusoe", 1998, 20, "Aventura"),
                Book.Create("lala", 2015, 20, "Carte pentru copii"),
                Book.Create("haha", 2010, 30, "Mister"),
                Book.Create("Capra cu 2 Iezi", 1998, 20, "Aventura")
            };

            var query = from Book in booksRepoMock
                group Book by Book.Genre
                into D
                select new {Genre = D.Key, MyBook = D.ToList()};
            result.Should().NotEqual(query.ToDictionary(D => D.Genre, D => D.MyBook));
        }

        [Fact]
        public void Given_RetriveAllBooksGroupedByGenreSQ_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var a = booksRepoMock.GroupBy(Book => Book.Genre).Select(D => new {Genre = D.Key, MyBook = D.ToList()});

            var query = a.ToDictionary(D => D.Genre, D => D.MyBook);

            SetupSystemUnderTest().RetriveAllBooksGroupedByGenreSM().Should().Equals(query);
        }


        [Fact]
        public void Given_RetriveAllOrderByPriceAscendingSM_When_BadRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceAscendingSM());
            var query = from Book in booksRepoMock orderby Book.Price select Book;
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByPriceAscendingSM_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceAscendingSM());
            var query = from Book in booksRepoMock orderby Book.Price descending select Book;
            result.Should().NotEqual(query);
        }


        [Fact]
        public void Given_RetriveAllOrderByPriceAscendingSQ_When_BadRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceAscendingSQ());
            var query = from Book in booksRepoMock orderby Book.Price select Book;
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByPriceAscendingSQ_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceAscendingSQ());
            var query = from Book in booksRepoMock orderby Book.Price descending select Book;
            result.Should().NotEqual(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByPriceDescedingSM_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceDescendingSM());
            var query = from Book in booksRepoMock orderby Book.Price descending select Book;
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByPriceDescedingSQ_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceDescendingSQ());
            var query = from Book in booksRepoMock orderby Book.Price select Book;
            result.Should().NotEqual(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByPriceDescedingSQ_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceDescendingSQ());
            var query = from Book in booksRepoMock orderby Book.Price descending select Book;
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByPriceDescedingSM_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByPriceDescendingSM());
            var query = from Book in booksRepoMock orderby Book.Price ascending select Book;
            result.Should().NotEqual(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByYearAscendingSM_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearAscendingSM());
            var query = booksRepoMock.OrderByDescending(Book => Book.Year);
            result.Should().NotEqual(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByYearAscendingSM_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearAscendingSM());
            var query = booksRepoMock.OrderBy(Book => Book.Year);
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByYearAscendingSQ_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearAscendingSQ());
            var query = from Book in booksRepoMock orderby Book.Year descending select Book;
            result.Should().NotEqual(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByYearAscendingSQ_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearAscendingSQ());
            var query = from Book in booksRepoMock orderby Book.Year select Book;
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByYearDescedingSM_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearDescendingSM());
            var query = from Book in booksRepoMock orderby Book.Year select Book;
            result.Should().NotEqual(query);
        }


        [Fact]
        public void Given_RetriveAllOrderByYearDescedingSM_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearDescendingSM());
            var query = from Book in booksRepoMock orderby Book.Year descending select Book;
            result.Should().Equal(query);
        }

        [Fact]
        public void Given_RetriveAllOrderByYearDescedingSQ_When_BadRepoIsPassed_Then_ShouldNotEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearDescendingSQ());
            var query = from Book in booksRepoMock orderby Book.Year select Book;
            result.Should().NotEqual(query);
        }


        [Fact]
        public void Given_RetriveAllOrderByYearDescedingSQ_When_GoodRepoIsPassed_Then_ShouldBeEqual()
        {
            var result = new List<Book>(SystemUnderTest.RetriveAllOrderByYearDescendingSQ());
            var query = from Book in booksRepoMock orderby Book.Year descending select Book;
            result.Should().Equal(query);
        }
    }
}