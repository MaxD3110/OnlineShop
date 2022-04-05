using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Wishlist;

namespace Shop.UI.Pages
{
    public class WishlistModel : PageModel
    {
        public IEnumerable<GetWish.Response> Wish { get; set; }

        public IActionResult OnGet([FromServices] GetWish getWish)
        {

            Wish = getWish.Do();

            return Page();
        }
    }
}
