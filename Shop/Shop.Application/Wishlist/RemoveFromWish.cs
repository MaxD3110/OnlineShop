using Shop.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Shop.Application.Wishlist
{
    [Service]
    public class RemoveFromWish
    {
        private ISessionManager _sessionManager;
        private IStockManager _stockManager;

        public RemoveFromWish(ISessionManager sessionManager, IStockManager stockManager)
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
            _sessionManager.RemoveProductFromWish(request.StockId);
            return true;
        }
    }
}
