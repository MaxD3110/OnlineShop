using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.ProductsAdmin;
using System.Collections.Generic;

namespace Shop.UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }

        public void OnGet([FromServices] GetProducts getProducts)
        {
            Products = getProducts.Do(); 
        }
    }
}
