using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace WebApplication1.DTOs
{
    public class StockModel
    { 
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public  void Update(Stock stock)
        {
            Id = stock.Id;
            Name = stock.Name;
            Code = stock.Code;
        }

        public static  IEnumerable<StockModel> ToStockModelsList(IEnumerable<Stock>stockList)
        {
            List<StockModel> stockModelList = new List<StockModel>();
            foreach (var stock in stockList)
            { 
                StockModel stockModel = new StockModel();
                stockModel.Update(stock);
                stockModelList.Add(stockModel);
            }
            return stockModelList;
        }
    }
}
