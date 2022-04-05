using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Posts
{
    [Service]
    public class GetPosts
    {
        private IPostManager _postManager;

        public GetPosts(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public IEnumerable<PostViewModel> Do() =>
            _postManager.GetAllPosts(x => new PostViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Body = x.Body,
                Category = x.Category,
                IsActive = x.IsActive,
                Description = x.Description,
                Image = x.Image,
                Created = x.Created,
                Tags = x.Tags,
            });

        public class PostViewModel
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
