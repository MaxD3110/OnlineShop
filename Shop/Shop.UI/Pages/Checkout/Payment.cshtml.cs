using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Shop.Application.Cart;
using Shop.Application.Orders;
using Shop.Domain.Infrastructure;
using Stripe;
using GetOrderCart = Shop.Application.Cart.GetOrder;

namespace Shop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public string PublicKey { get; }
        public IEnumerable<GetCart.Response> Cart { get; set; }
        public PaymentModel (IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
        }

        public IActionResult OnGet([FromServices] GetCustomerInformation getCustomerInformation, [FromServices] GetCart getCart)
        {
            Cart = getCart.Do();
            var information = getCustomerInformation.Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(
            string stripeEmail, 
            string stripeToken,
            [FromServices] GetOrderCart getOrder,
            [FromServices] CreateOrder createOrder,
            [FromServices] ISessionManager sessionManager)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();
            var cartOrder = getOrder.Do();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
                {
                Amount = cartOrder.GetTotalCharge(),
                Description = "Shop Purchase",
                Currency = "usd",
                Customer = customer.Id
                });

            var sessionId = HttpContext.Session.Id;

            await createOrder.Do(new CreateOrder.Request
            {
                StripeReference = charge.Id,
                SessionId = sessionId, 
                FirstName = cartOrder.CustomerInformation.FirstName,
                LastName = cartOrder.CustomerInformation.LastName,
                Email = cartOrder.CustomerInformation.Email,
                PhoneNumber = cartOrder.CustomerInformation.PhoneNumber,
                Address1 = cartOrder.CustomerInformation.Address1,
                Address2 = cartOrder.CustomerInformation.Address2,
                City = cartOrder.CustomerInformation.City,
                PostCode = cartOrder.CustomerInformation.PostCode,
                Wishes = cartOrder.CustomerInformation.Wishes,

                Stocks = cartOrder.Products.Select(x => new CreateOrder.Stock
                {
                    StockId = x.StockId,
                    Qty = x.Qty
                }).ToList()
            });

            sessionManager.ClearCart();

            return RedirectToPage("/Index");
        }

    }
}
