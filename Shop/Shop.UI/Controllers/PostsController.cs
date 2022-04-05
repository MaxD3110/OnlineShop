using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Posts;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    //[Authorize(Policy = "Manager")]
    public class PostsController : Controller
    {

        [HttpGet("")]
        public IActionResult GetPosts([FromServices] GetPosts getPosts) => Ok(getPosts.Do());

        [HttpGet("{id}")]
        public IActionResult GetPost(int id, [FromServices] GetPost getPost) => Ok(getPost.Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreatePost([FromForm] CreatePost.Request request,
            [FromServices] CreatePost createPost) => Ok((await createPost.Do(request)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id,
            [FromServices] DeletePost deletePost) => Ok((await deletePost.Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdatePost([FromForm] UpdatePost.Request request,
            [FromServices] UpdatePost updatePost) => Ok((await updatePost.Do(request)));

    }
}
