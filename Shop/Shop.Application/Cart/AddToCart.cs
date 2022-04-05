using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System.Threading.Tasks;

namespace Shop.Application.Cart
{
    [Service]
    public class AddToCart
    {
        private ISessionManager _sessionManager;
        private IStockManager _stockManager;

        public AddToCart(ISessionManager sessionManager, IStockManager stockManager)
        {
            _sessionManager = sessionManager;
            _stockManager = stockManager;
        }

        public class Request
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        public async Task<bool> Do(Request request)
        {
            if(!_stockManager.EnoughStock(request.StockId, request.Qty))
            {
                return false;
            }

            await _stockManager.PutStockOnHold(request.StockId, request.Qty, _sessionManager.GetId());

            var stock = _stockManager.GetStockWithProduct(request.StockId);
            var cartProduct = new CartProduct()
            {
                ProductId = stock.ProductId,
                ProductName = stock.Product.Name,
                ProductDescription = stock.Product.Description,
                StockId = stock.Id,
                Qty = request.Qty,
                Value = stock.Value - (stock.Value * (stock.IsOnSale)/100),
                Image = stock.PropImage,
                Description = stock.Description
            };

            _sessionManager.AddProduct(cartProduct);
            
            return true;
        }
    }
}
