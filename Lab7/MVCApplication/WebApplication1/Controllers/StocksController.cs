using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Data.Domain.Interfaces;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Persistence;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    public class StocksController : Controller
    {
        private readonly IStockRepository _stockRepo;

        public StocksController(IStockRepository stockService)
        {
            EnsureArg.IsNotNull(stockService);
            _stockRepo = stockService;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            
            IEnumerable<StockModel> stockModelList = StockModel.ToStockModelsList(_stockRepo.GetAll());
          
            return View(stockModelList);
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _stockRepo.GetById(id);
            var stockModel=new StockModel();
            stockModel.Update(stock);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stockModel);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {

                stockModel.Id = Guid.NewGuid();
                Stock stock = Stock.Create(stockModel.Id,stockModel.Name,stockModel.Code);

                _stockRepo.Add(stock);
                return RedirectToAction(nameof(Index));
            }
            return View(stockModel);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _stockRepo.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }
            StockModel stockModel=new StockModel();
            stockModel.Update(stock);
            return View(stockModel);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Code")] StockModel stockModel)
        {
            if (id != stockModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stock = _stockRepo.GetById(stockModel.Id);
                    _stockRepo.Edit(stock);
                    stockModel.Update(stock);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stockModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }


            return View(stockModel);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StockModel stockModel = new StockModel();
            var stock = _stockRepo.GetById(id);
            stockModel.Update(stock);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stockModel);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            _stockRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(Guid id)
        {
            if (_stockRepo.GetById(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
