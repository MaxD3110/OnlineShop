using Microsoft.AspNetCore.Http;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Infrastructure
{
    public interface IPostManager
    {
        Task<int> CreatePost(Post post);
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);
        Task<int> DeletePost(int id);
        Task<int> UpdatePost(Post post);
        TResult GetPostByName<TResult>(string name, Func<Post, TResult> selector);
        TResult GetPostById<TResult>(int id, Func<Post, TResult> selector);
        IEnumerable<TResult> GetAllPosts<TResult>(Func<Post, TResult> selector);
    }
}
