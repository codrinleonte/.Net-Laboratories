using System;

namespace Lab3
{
    public class Record
    {
        private Record()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Title { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public int Value { get; private set; }

        public static Record Create(string title, DateTime startDate, DateTime endDate, int value)
        {
            return new Record
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Value = value
            };
        }
    }
}