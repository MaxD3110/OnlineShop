using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.OrdersAdmin;

namespace Shop.UI.Pages.Admin
{
    public class OrderManagementModel : PageModel
    {

        public IEnumerable<GetOrders.Response> Order { get; set; }
        public IActionResult OnGet(int id,[FromServices] GetOrders getOrders)
        {

            Order = getOrders.Do(id);
            return Page();
        }
    }
}
