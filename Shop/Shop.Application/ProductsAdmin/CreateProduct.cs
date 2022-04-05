using Shop.Domain.Models;
using System;
using System.Threading.Tasks;
using Shop.Domain.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.ProductsAdmin
{
    [Service]
    public class CreateProduct
    {
        private IProductManager _productManager;

        public CreateProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Category = request.Category,
                FullDescription = request.FullDescription,
                AvRating = request.AvRating,
                Image = request.ImageAdded == "not" ? "undefined.jpg" : await _productManager.SaveImage(request.Image),
                DateTime = DateTime.Now.ToString("dd/MM/yyyy"),
                IsNew = request.IsNew,
                IsTrending = request.IsTrending,
                IsActive = request.IsActive
        };

            if(await _productManager.CreateProduct(product) <= 0)
            {
                throw new Exception("Failed to create product");
            }

            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                FullDescription = product.FullDescription,
                AvRating = product.AvRating,
                Value = product.Value,
                Image = product.Image,
                DateTime = DateTime.Now.ToString("dd/MM/yyyy"),
                IsNew = product.IsNew,
                IsTrending = product.IsTrending,
                IsActive = product.IsActive,
                Category = product.Category
            };
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public string FullDescription { get; set; }
            public decimal AvRating { get; set; }
            public IFormFile Image { get; set; }

            public string Category { get; set; }
            public string DateTime { get; set; }
            public bool IsTrending { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }
            public string ImageAdded { get; set; }

        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string FullDescription { get; set; }
            public decimal AvRating { get; set; }
            public decimal Value { get; set; }
            public string Image { get; set; }
            public string Category { get; set; }
            public string DateTime { get; set; }
            public bool IsTrending { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }
            public string StillImage { get; set; }
            public string ImageAdded { get; set; }
        }
    }
}
