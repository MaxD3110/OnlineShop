using Microsoft.AspNetCore.Http;
using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Posts
{
    [Service]
    public class UpdatePost
    {
        private IPostManager _postManager;

        public UpdatePost(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public async Task<Response> Do(Request request)
        {
            var post = _postManager.GetPostById(request.Id, x => x);

            post.Title = request.Title;
            post.Description = request.Description;
            post.Body = request.Body;
            post.Category = request.Category;
            post.Tags = request.Tags;
            post.IsActive = request.IsActive;

            if (request.ImageAdded == "not")
            {
                post.Image = request.StillImage;
            }
            else
            {
                post.Image = await _postManager.SaveImage(request.Image);

            }

            await _postManager.UpdatePost(post);

            return new Response
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Category = post.Category,
                IsActive = post.IsActive,
                Description = post.Description,
                Image = post.Image,
                Tags = post.Tags,

            };
        }

        public class Request
        {
            public int Id { get; set; }

            public string Title { get; set; }
            public string Body { get; set; }
            public IFormFile Image { get; set; }
            public bool IsActive { get; set; }
            public string Description { get; set; }
            public string Tags { get; set; }
            public string Category { get; set; }
            public string ImageAdded { get; set; }
            public string StillImage { get; set; }

        }

        public class Response
        {
            public int Id { get; set; }

            public string Title { get; set; }
            public string Body { get; set; }
            public string Image { get; set; }
            public bool IsActive { get; set; }
            public string Description { get; set; }
            public string Tags { get; set; }
            public string Category { get; set; }
            public string ImageAdded { get; set; }
        }
    }
}
