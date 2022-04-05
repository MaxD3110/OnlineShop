using Microsoft.AspNetCore.Mvc;
using Shop.Application.Compare;

namespace Shop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CompareController : Controller
    {
        [HttpPost("{ids}")]
        public IActionResult AddOneCompare(string ids, [FromServices] AddToCompare addToCompare)
        {
            var request = new AddToCompare.Request
            {
                Key = ids
            };

            var success = addToCompare.Do(request);
            if (success)
            {
                return Ok("Item Added to Wish");
            }
            return BadRequest("Failed add");

        }

        [HttpPost("{stockId}")]
        public IActionResult RemoveCompare(int stockId, [FromServices] RemoveFromCompare removeFromCompare)
        {
            var request = new RemoveFromCompare.Request
            {
                StockId = stockId,
            };

            var success = removeFromCompare.Do(request);
            if (success)
            {
                return Ok("Item Removed from Wish");
            }
            return BadRequest("Failed remove");

        }

        [HttpGet]
        public IActionResult GetCompareMain([FromServices] GetCompare getCompare)
        {
            var compare = getCompare.Do();
            return PartialView("_ComparePartial", compare);
        }

        [HttpGet]
        public IActionResult GetCompareMedium([FromServices] GetCompare getCompare)
        {
            var compare = getCompare.Do();
            return PartialView("Components/Cart/MediumCompare", compare);
        }
    }
}
