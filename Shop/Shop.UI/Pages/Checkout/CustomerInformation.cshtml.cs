using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using System.Collections.Generic;

namespace Shop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private IHostingEnvironment _env;

        public CustomerInformationModel(IHostingEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }
        [BindProperty]
        public IEnumerable<GetCart.Response> Cart { get; set; }

        public IActionResult OnGet([FromServices] GetCustomerInformation getCustomerInformation, [FromServices] GetCart getCart)
        {
            Cart = getCart.Do();
            var information = getCustomerInformation.Do();

            if(information == null)
            {
                if(_env.IsDevelopment())
                {
                    CustomerInformation = new AddCustomerInformation.Request
                    {
                        FirstName = "A",
                        LastName = "A",
                        Email = "A@a.com",
                        PhoneNumber = "11111",
                        Address1 = "A",
                        Address2 = "A",
                        City = "A",
                        PostCode = "A"
                    };
                }
                return Page();
            }
            else
            {
                return RedirectToPage("/Checkout/Payment");
            }
        }

        public IActionResult OnPost([FromServices] AddCustomerInformation addCustomerInformation, [FromServices] GetCart getCart)
        {
            if(!ModelState.IsValid)
            {
                Cart = getCart.Do();
                return Page();
            }

            addCustomerInformation.Do(CustomerInformation);

            return RedirectToPage("/Checkout/Payment");
        }

    }
}
