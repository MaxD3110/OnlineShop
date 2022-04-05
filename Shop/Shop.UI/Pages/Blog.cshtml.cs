using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Posts;

namespace Shop.UI.Pages
{
    public class BlogModel : PageModel
    {
        public IEnumerable<GetPosts.PostViewModel> Posts { get; set; }
        public void OnGet([FromServices] GetPosts getPosts)
        {
            Posts = getPosts.Do();
        }
    }
}
