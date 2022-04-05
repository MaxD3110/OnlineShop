using Microsoft.AspNetCore.Mvc;
using Shop.Application.Wishlist;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class WishController :Controller
    {
        [HttpPost("{stockId}")]
        public IActionResult AddOneWish(int stockId, [FromServices] AddToWish addToWish)
        {
            var request = new AddToWish.Request
            {
                StockId = stockId,
            };

            var success = addToWish.Do(request);
            if (success)
            {
                return Ok("Item Added to Wish");
            }
            return BadRequest("Failed add");

        }

        [HttpPost("{stockId}")]
        public IActionResult RemoveWish(int stockId, [FromServices] RemoveFromWish removeFromWish)
        {
            var request = new RemoveFromWish.Request
            {
                StockId = stockId,
            };

            var success = removeFromWish.Do(request);
            if (success)
            {
                return Ok("Item Removed from Wish");
            }
            return BadRequest("Failed remove");

        }

        [HttpGet]
        public IActionResult GetWishComponent([FromServices] GetWish getWish)
        {
            var totalValue = getWish.Do().Count();
            return PartialView("Components/Cart/SmallWish", totalValue);
        }

        [HttpGet]
        public IActionResult GetWishMain([FromServices] GetWish getWish)
        {
            var wish = getWish.Do();
            return PartialView("_WishPartial", wish);
        }
    }
}
