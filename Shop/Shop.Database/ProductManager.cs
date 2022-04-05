using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class ProductManager : IProductManager
    {
        private ApplicationDbContext _ctx;
        private string _imagePath;

        public ProductManager(ApplicationDbContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _imagePath = config["Path:Images"];
        }


        public Task<int> CreateProduct(Product product)
        {
            _ctx.Products.Add(product);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteProduct(int id)
        {
            var product = _ctx.Products.FirstOrDefault(x => x.Id == id);
            _ctx.Products.Remove(product);
            return _ctx.SaveChangesAsync();
        }

        public TResult GetProductById<TResult>(int id, Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Stock)
            .Include(x => x.Specification)
            .Include(x => x.Review)
            .Where(x => x.Id == id)
            .Select(selector)
               .FirstOrDefault();
        }

        public TResult GetProductByName<TResult>(string name, Func<Product, TResult> selector)
        {
          return _ctx.Products
            .Include(x => x.Stock)
            .Include(x => x.Specification)
            .Include(x => x.Review)
            .Where(x => x.Name == name)
            .Select(selector)
               .FirstOrDefault();
        }

        public IEnumerable<TResult> GetProductsWithStock<TResult>(Func<Product, TResult> selector)
        {
            return _ctx.Products
            .Include(x => x.Stock)
            .Include(x => x.Specification)
            .Include(x => x.Review)
            .Select(selector).ToList();
        }

        public Task<int> UpdateProduct(Product product)
        {
            _ctx.Products.Update(product);

            return _ctx.SaveChangesAsync();
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

        public IEnumerable<TResult> GetProductsWithReview<TResult>(Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Review)
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetProductsWithSpecification<TResult>(Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Specification)
                .Select(selector)
                .ToList();
        }
    }
}
