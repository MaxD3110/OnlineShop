using Microsoft.AspNetCore.Http;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    [Service]
    public class CreateStock
    {
        private readonly IStockManager _stockManager;

        public CreateStock(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                Qty = request.Qty,
                Value = request.Value,
                IsOnSale = request.IsOnSale,
                IsActive = request.IsActive,
                PropImage = request.IsImageRequested == "not" ? request.StillImage : await _stockManager.SaveImage(request.PropImage),
                ProductId = request.ProductId,
                Color = request.Color,
            };

            await _stockManager.CreateStock(stock);

            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Qty = stock.Qty,
                Value = stock.Value,
                IsActive = stock.IsActive,
                IsOnSale = stock.IsOnSale,
                PropImage = stock.PropImage, /*== "null" ? request.StillImage : "undefined.jpg",*/
            Color = stock.Color,
            };
        }

        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public IFormFile PropImage { get; set; }
            public int Qty { get; set; }
            public string IsImageRequested { get; set; }
            public string StillImage { get; set; }
            public decimal Value { get; set; }
            public string Color { get; set; }
            public int IsOnSale { get; set; }
            public bool IsActive { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string PropImage { get; set; }
            public int Qty { get; set; }
            public decimal Value { get; set; }
            public string Color { get; set; }
            public int IsOnSale { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
