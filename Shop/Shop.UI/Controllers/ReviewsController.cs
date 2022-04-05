using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ReviewAdmin;
using Shop.Application.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    //[Authorize(Policy = "Manager")]
    public class ReviewsController : Controller
    {
        [HttpGet("")]
        public IActionResult GetReview([FromServices] GetReview getReview) => Ok(getReview.Do());

        [HttpPost("")]
        public async Task<IActionResult> AddReview([FromBody] AddReview.Request request,
            [FromServices] AddReview addReview) => Ok((await addReview.Do(request)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id,
            [FromServices] DeleteReview deleteReview) => Ok((await deleteReview.Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReview.Request request,
            [FromServices] UpdateReview updateReview) => Ok((await updateReview.Do(request)));
    }
}
