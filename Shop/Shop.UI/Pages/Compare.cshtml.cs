using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Compare;

namespace Shop.UI.Pages
{
    public class CompareModel : PageModel
    {
        public IEnumerable<GetCompare.Response> Compare { get; set; }

        public IActionResult OnGet([FromServices] GetCompare getCompare)
        {

            Compare = getCompare.Do();

            return Page();
        }
    }
}
