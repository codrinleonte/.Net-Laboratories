using System;
using Data.Domain.Entities;
using Data.Domain.Interface;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/stocks")]
    public class StockController : Controller
    {
        private readonly IStockRepository stockService;

        public StockController(IStockRepository stockService)
        {
            EnsureArg.IsNotNull(stockService);
            this.stockService = stockService;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = stockService.GetAll();
            return Ok(stocks);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            EnsureArg.IsNotEmpty(id);
            var stock = stockService.GetById(id);
            if (stock == null)
                return NotFound();
            return Ok(stock);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] Stock stock)
        {
            EnsureArg.IsNotNull(stock);
            stockService.Add(stock);
            return Ok();
            //return CreatedAtRoute()
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Edit(Guid id, [FromBody] Stock stock)
        {
            EnsureArg.IsNotEmpty(id);
            EnsureArg.IsNotNull(stock);

            var edit = stockService.GetById(id);
            if (edit == null)
                return NotFound();
            edit.Update(stock.Name, stock.Code, stock.StockRecords);
            stockService.Edit(edit);

            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            stockService.Delete(id);
            return NoContent();
        }
    }
}