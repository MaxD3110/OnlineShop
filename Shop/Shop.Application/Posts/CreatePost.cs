using Microsoft.AspNetCore.Http;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Shop.Application.Posts
{
    [Service]
    public class CreatePost
    {
        private IPostManager _postManager;

        public CreatePost(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public async Task<Response> Do(Request request)
        {
            var post = new Post
            {
                Title = request.Title,
                Body = request.Body,
                Category = request.Category,
                IsActive = request.IsActive,
                Description = request.Description,
                Image = request.ImageAdded == "not" ? "undefined.jpg" : await _postManager.SaveImage(request.Image),
                Created = DateTime.Now.ToString("dd MMMM yyyy"),
                Tags = request.Tags,
            };

            if (await _postManager.CreatePost(post) <= 0)
            {
                throw new Exception("Failed to create product");
            }

            return new Response
            {
                Title = post.Title,
                Body = post.Body,
                Category = post.Category,
                IsActive = post.IsActive,
                Description = post.Description,
                Image = post.Image,
                Created = DateTime.Now.ToString("dd MMMM yyyy"),
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
            public string Created { get; set; }

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
            public string Created { get; set; }
        }
    }
}
