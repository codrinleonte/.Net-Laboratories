using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class StockRecord
    {
        private StockRecord()
        {
        }

        [Required]
        public Guid Id { get; private set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double StartPrice { get; set; }

        [Required]
        public double EndPrice { get; set; }

        public StockRecord Create(DateTime date, double startPrice, double EndPrice)
        {
            var instance = new StockRecord {Id = Guid.NewGuid()};
            instance.Update(date, startPrice, EndPrice);
            return instance;
        }

        public void Update(DateTime date, double startPrice, double endPrice)
        {
            Date = date;
            StartPrice = startPrice;
            EndPrice = endPrice;
        }
    }
}