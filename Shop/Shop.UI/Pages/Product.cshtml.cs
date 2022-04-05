using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Application.Compare;
using Shop.Application.Products;
using Shop.Application.Wishlist;
using Shop.Database;

namespace Shop.UI.Pages
{
    public class ProductModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public ProductModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }
        [BindProperty]
        public AddToWish.Request WishViewModel { get; set; }
        [BindProperty]
        public AddToCompare.Request CompareViewModel { get; set; }

        public GetProduct.ProductViewModel Product { get; set; }
        public async Task<IActionResult> OnGet(string name, [FromServices] GetProduct getProduct)
        {
            Product = await getProduct.Do(name.Replace("-", " "));
            if (Product == null)
                return RedirectToPage("Index");
            else
                return Page();

        }
        //public IActionResult OnPostWishAdd([FromServices] AddToWish addToWish)
        //{
        //    var stockAdded = addToWish.Do(WishViewModel);

        //    if (stockAdded)
        //        return RedirectToPage("Wishlist");
        //    else
        //        return Page();
        //}

        public async Task<IActionResult> OnPost([FromServices] AddToCart addToCart)
        {
            var stockAdded = await addToCart.Do(CartViewModel);

            if (stockAdded)
            {
                return RedirectToPage("Cart");
            }
            else
            {
                return Page();
            }
        }
    }
}
