using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    //[Authorize(Policy = "Manager")]
    public class SpecificationsController : Controller
    {
        [HttpGet("")]
        public IActionResult GetSpecification([FromServices] GetSpecification getSpecification) => Ok(getSpecification.Do());

        [HttpPost("")]
        public async Task<IActionResult> AddSpecification([FromBody] AddSpecification.Request request,
            [FromServices] AddSpecification addSpecification) => Ok((await addSpecification.Do(request)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecification(int id,
            [FromServices] DeleteSpecification deleteSpecification) => Ok((await deleteSpecification.Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdateSpecification([FromBody] UpdateSpecification.Request request,
            [FromServices] UpdateSpecification updateSpecification) => Ok((await updateSpecification.Do(request)));
    }
}
