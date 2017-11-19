using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interface;
using Data.Persistence;

namespace Business
{
    public class StockRepository : IStockRepository
    {
        private readonly IDatabaseService _databaseService;

        public StockRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void Add(Stock stock)
        {
            _databaseService.Stocks.Add(stock);
            _databaseService.SaveChanges();
        }

        public void Edit(Stock stock)
        {
            _databaseService.Stocks.Update(stock);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var stock = GetById(id);
            _databaseService.Stocks.Remove(stock);
            _databaseService.SaveChanges();
        }

        public IReadOnlyList<Stock> GetAll()
        {
            return _databaseService.Stocks.ToList();
        }

        public Stock GetById(Guid id)
        {
            return _databaseService.Stocks.FirstOrDefault(t => t.Id == id);
        }
    }
}