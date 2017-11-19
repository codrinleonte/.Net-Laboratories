using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Interfaces;
using Data.Persistence;
using Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using WebApplication1.DTOs;

namespace Business
{
    public class StockRepository : IStockRepository
    {
        private readonly IDatabaseContext _databaseContext;
        
        public StockRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Stock stock)
        {
            _databaseContext.Stocks.Add(stock);
            _databaseContext.SaveChanges();
        }

        public void Edit(Stock stock)
        {
            _databaseContext.Stocks.Update(stock);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var stock = GetById(id);
            _databaseContext.Stocks.Remove(stock);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<Stock> GetAll()
        {
            return _databaseContext.Stocks.ToList();
        }

        public Stock GetById(Guid id)
        {
            return _databaseContext.Stocks.FirstOrDefault(t => t.Id == id);
        }
    }
}