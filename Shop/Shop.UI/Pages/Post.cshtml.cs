using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Posts;

namespace Shop.UI.Pages
{
    public class PostModel : PageModel
    {
        public GetPost.PostViewModel Post { get; set; }
        public IActionResult OnGet(int id, [FromServices] GetPost getPost)
        {
            Post =  getPost.Do(id);
            if (Post == null)
                return RedirectToPage("Index");
            else
                return Page();

        }
    }
}
