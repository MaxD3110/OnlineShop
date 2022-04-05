using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Compare
{
    [Service]
    public class RemoveFromCompare
    {
        private ISessionManager _sessionManager;
        private IStockManager _stockManager;

        public RemoveFromCompare(ISessionManager sessionManager, IStockManager stockManager)
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
            _sessionManager.RemoveProductFromCompare(request.StockId);
            return true;
        }
    }
}
