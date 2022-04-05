using Microsoft.AspNetCore.Http;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    [Service]
    public class UpdateStock
    {
        private readonly IStockManager _stockManager;
        public UpdateStock(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public async Task<Response> Do(Request request)
        {
            var stockList = new List<Stock>();

            foreach(var stock in request.Stock)
            {
                stockList.Add(new Stock
                {
                    Id = stock.Id,
                    Description = stock.Description,
                    Qty = stock.Qty,
                    Value = stock.Value,
                    IsActive = stock.IsActive,
                    IsOnSale = stock.IsOnSale,
                    ProductId = stock.ProductId,
                    PropImage = stock.PropImage,
                    Color = stock.Color,

            });
            }

            await _stockManager.UpdateStockRange(stockList);

            return new Response
            {
                Stock = request.Stock
            };
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public decimal Value { get; set; }
            public int IsOnSale { get; set; }
            public bool IsActive { get; set; }
            public string Color { get; set; }
            public string PropImage { get; set; }
        }

        public class Request
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class Response
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}
