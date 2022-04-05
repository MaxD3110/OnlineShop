using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Infrastructure;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Shop.Database
{
    public class StockManager : IStockManager
    {
        private ApplicationDbContext _ctx;
        private string _imagePath;

        public StockManager(ApplicationDbContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _imagePath = config["Path:Images"];
        }

        public Task<int> CreateStock(Stock stock)
        {
            _ctx.Stock.Add(stock);
            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteStock(int id)
        {
            var stock = _ctx.Stock.FirstOrDefault(x => x.Id == id);

            _ctx.Stock.Remove(stock);

            return _ctx.SaveChangesAsync();
        }

        public bool EnoughStock(int stockId, int qty)
        {
            return _ctx.Stock.FirstOrDefault(x => x.Id == stockId).Qty >= qty;
        }

        public Stock GetStockWithProduct(int stockId)
        {
            return _ctx.Stock.Include(x => x.Product).FirstOrDefault(x => x.Id == stockId);
        }

        public Task PutStockOnHold(int stockId, int qty, string sessionId)
        {
            _ctx.Stock.FirstOrDefault(x => x.Id == stockId).Qty -= qty;

            var stockOnHold = _ctx.StocksOnHold.Where(x => x.SessionId == sessionId).ToList();
            if (stockOnHold.Any(x => x.StockId == stockId))
            {
                stockOnHold.Find(x => x.StockId == stockId).Qty += qty;
            }
            else
            {

                _ctx.StocksOnHold.Add(new StockOnHold
                {
                    StockId = stockId,
                    SessionId = sessionId,
                    Qty = qty,
                    ExpiryDate = DateTime.Now.AddMinutes(20)
                });
            }

            foreach (var stock in stockOnHold)
            {
                stock.ExpiryDate = DateTime.Now.AddMinutes(20);
            }


            return _ctx.SaveChangesAsync();
        }
        public Task RemoveStockFromHold(string sessionId)
        {
            var stockOnHold = _ctx.StocksOnHold
                .Where(x => x.SessionId == sessionId)
                .ToList();

            _ctx.StocksOnHold.RemoveRange(stockOnHold);
            return _ctx.SaveChangesAsync();
        }

        public Task RemoveStockFromHold(int stockId, int qty, string sessionId)
        {
            var stockOnHold = _ctx.StocksOnHold
              .FirstOrDefault(x => x.StockId == stockId && x.SessionId == sessionId);
            var stock = _ctx.Stock.FirstOrDefault(x => x.Id == stockId);
            stock.Qty += qty;
            stockOnHold.Qty -= qty;

            if (stockOnHold.Qty <= 0)
            {
                _ctx.Remove(stockOnHold);
            }

            return _ctx.SaveChangesAsync();
        }

        public Task RetrieveExpiredStockOnHold()
        {
            var stocksOnHold = _ctx.StocksOnHold.Where(x => x.ExpiryDate < DateTime.Now).ToList();
            var stockIds = stocksOnHold.Select(y => y.StockId).ToArray();

            if (stocksOnHold.Count > 0)
            {
                var stockToReturn = _ctx.Stock.Where(x => stockIds.Contains(x.Id)).ToList();

                foreach (var stock in stockToReturn)
                {
                    stock.Qty = stock.Qty + stocksOnHold.FirstOrDefault(x => x.StockId == stock.Id).Qty;
                }

                _ctx.StocksOnHold.RemoveRange(stocksOnHold);

                return _ctx.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public Task<int> UpdateStockRange(List<Stock> stockList)
        {
            _ctx.Stock.UpdateRange(stockList);
            return _ctx.SaveChangesAsync();
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            var save_path = Path.Combine(_imagePath);
            if (!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);
            }

            var mime = image.FileName.Substring(image.FileName.LastIndexOf("."));
            var file_name = $"img_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}{mime}";

            using (var fileStream = new FileStream(Path.Combine(save_path, file_name), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return file_name;
        }
    }
}
