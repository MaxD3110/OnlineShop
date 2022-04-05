using Shop.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Shop.Application.OrdersAdmin
{
    [Service]
    public class DecreaseOrder
    { 
        private IOrderManager _orderManager;
        public DecreaseOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public Task<int> DoAsync(int id)
        {
            return _orderManager.DecreaseOrder(id);
        }
    }
}
