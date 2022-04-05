using Shop.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.OrdersAdmin
{
    [Service]
    public class GetOrder
    {
        private IOrderManager _orderManager;
        public GetOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }
            public string StripeReference { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
            public string Wishes { get; set; }
            public string OrderDate { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public string StockDescription { get; set; }
            public string Image { get; set; }
            public decimal Value { get; set; }
            public decimal TotalValue { get; set; }
        }

        public Response Do(int id) =>
            _orderManager.GetOrderById(id, x => new Response
            {
                Id = x.Id,
                OrderRef = x.OrderRef,
                StripeReference = x.StripeReference,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                PostCode = x.PostCode,
                Wishes = x.Wishes,
                OrderDate = x.OrderDate,

                Products = x.OrderStocks.Select(y => new Product
                {
                    Name = y.Stock.Product.Name,
                    Description = y.Stock.Product.Description,
                    Image = y.Stock.PropImage,
                    Qty = y.Qty,
                    Value = y.Stock.Product.Value,
                    TotalValue = y.Stock.Product.Value * y.Qty,
                    StockDescription = y.Stock.Description,
                }),
            });
}
}
