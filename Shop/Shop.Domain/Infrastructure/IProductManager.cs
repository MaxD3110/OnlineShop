using Microsoft.AspNetCore.Http;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Shop.Domain.Infrastructure
{
    public interface IProductManager
    {
        Task<int> CreateProduct(Product product);
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);
        Task<int> DeleteProduct(int id);
        Task<int> UpdateProduct(Product product);
        TResult GetProductByName<TResult>(string name, Func<Product, TResult> selector);
        TResult GetProductById<TResult>(int id, Func<Product, TResult> selector);
        IEnumerable<TResult> GetProductsWithStock<TResult>(Func<Product, TResult> selector);
        IEnumerable<TResult> GetProductsWithReview<TResult>(Func<Product, TResult> selector);
        IEnumerable<TResult> GetProductsWithSpecification<TResult>(Func<Product, TResult> selector);
    }
}
