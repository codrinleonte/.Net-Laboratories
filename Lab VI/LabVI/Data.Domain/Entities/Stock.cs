using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
   public  class Stock
    {
        private Stock()
        {
        }

        [Required]
        public Guid Id { get; private set; }
        [Required]
        public string Name { get;set; }
        [Required]
        public int Code { get; set; }

        public List<StockRecord> StockRecords
        {
            get; set;
        }

        public  Stock Create( string name, int code, List<StockRecord> stockRecords)
        {
            var instance = new Stock { Id = Guid.NewGuid() };
            instance.Update(name, code, stockRecords);
            return instance;
        }

        public void Update(string name, int code, List<StockRecord> stockRecords)
        {
            Name = name;
            Code = code;
            StockRecords = stockRecords;
        }
    }
}
