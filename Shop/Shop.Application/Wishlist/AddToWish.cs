using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System.Threading.Tasks;

namespace Shop.Application.Wishlist
{
    [Service]
    public class AddToWish
    {
        private ISessionManager _sessionManager;
        private IStockManager _stockManager;

        public AddToWish(ISessionManager sessionManager, IStockManager stockManager)
        {
            _sessionManager = sessionManager;
            _stockManager = stockManager;
        }

        public class Request
        {
            public int StockId { get; set; }
        }

        public bool Do(Request request)
        {

            var stock = _stockManager.GetStockWithProduct(request.StockId);
            var wishProduct = new CartProduct()
            {
                ProductId = stock.ProductId,
                ProductName = stock.Product.Name,
                StockId = stock.Id,
                Value = stock.Value - (stock.Value * (stock.IsOnSale) / 100),
                ProductDescription = stock.Product.Description,
                Image = stock.PropImage,
                Description = stock.Description,
                Sqty = stock.Qty
            };

            _sessionManager.AddProductToWish(wishProduct);

            return true;
        }
    }
}
