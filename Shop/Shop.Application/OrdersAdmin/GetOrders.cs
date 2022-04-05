using Shop.Domain.Enums;
using Shop.Domain.Infrastructure;
using System.Collections.Generic;

namespace Shop.Application.OrdersAdmin
{
    [Service]
    public class GetOrders
    {
        private readonly IOrderManager _orderManager;

        public GetOrders(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Wishes { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
            public string OrderDate { get; set; }
        }
        public IEnumerable<Response> Do(int status) =>
        _orderManager.GetOrdersByStatus((OrderStatus)status, x => new Response
        {
            Id = x.Id,
            OrderRef = x.OrderRef,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            Address1 = x.Address1,
            Address2 = x.Address2,
            City = x.City,
            PostCode = x.PostCode,
            Wishes = x.Wishes,
            OrderDate = x.OrderDate
        });
    }
}
