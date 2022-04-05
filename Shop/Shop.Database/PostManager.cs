using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class PostManager : IPostManager
    {
        private ApplicationDbContext _ctx;
        private string _imagePath;

        public PostManager(ApplicationDbContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _imagePath = config["Path:PostImages"];
        }
        public Task<int> CreatePost(Post post)
        {
            _ctx.Posts.Add(post);
            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeletePost(int id)
        {
            var post = _ctx.Posts.FirstOrDefault(x => x.Id == id);
            _ctx.Posts.Remove(post);
            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetAllPosts<TResult>(Func<Post, TResult> selector)
        {
            return _ctx.Posts
            .Select(selector).ToList();
        }

        public TResult GetPostById<TResult>(int id, Func<Post, TResult> selector)
        {
            return _ctx.Posts
            .Where(x => x.Id == id)
            .Select(selector)
               .FirstOrDefault();
        }

        public TResult GetPostByName<TResult>(string name, Func<Post, TResult> selector)
        {
            return _ctx.Posts
            .Where(x => x.Title == name)
            .Select(selector)
               .FirstOrDefault();
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            var save_path = Path.Combine(_imagePath);
            if (!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);
            }

            var mime = image.FileName.Substring(image.FileName.LastIndexOf("."));
            var file_name = $"img_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}{mime}";

            using (var fileStream = new FileStream(Path.Combine(save_path, file_name), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return file_name;
        }

        public Task<int> UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);

            return _ctx.SaveChangesAsync();
        }
    }
}
