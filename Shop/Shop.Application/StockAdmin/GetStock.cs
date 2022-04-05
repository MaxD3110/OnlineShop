using Shop.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.StockAdmin
{
    [Service]
    public class GetStock
    {
        private IProductManager _productManager;

        public GetStock(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IEnumerable<ProductViewModel> Do()
        {
            return _productManager.GetProductsWithStock(x => new ProductViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Image = x.Image,
                Stock = x.Stock.Select(y => new StockViewModel
                {
                    Id = y.Id,
                    Description = y.Description,
                    Qty = y.Qty,
                    Value = y.Value,
                    IsOnSale = y.IsOnSale,
                    IsActive = y.IsActive,
                    PropImage = y.PropImage,
                    Color = y.Color,
                })
            });
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public decimal Value { get; set; }
            public int IsOnSale { get; set; }
            public bool IsActive { get; set; }
            public string Color { get; set; }
            public string PropImage { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}
