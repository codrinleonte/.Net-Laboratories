using System;
using EnsureThat;

namespace Lab
{
    public class Book
    {
        private Book()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public int Price { get; private set; }
        public string Genre { get; private set; }

        public static Book Create(string title, int year, int price, string genre)
        {
            EnsureArg.IsLt(title.Length,100);
            return new Book
            {
                Title = title,
                Year = year,
                Price = price,
                Genre = genre
            };
        }
    }
}