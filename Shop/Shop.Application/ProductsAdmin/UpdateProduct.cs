using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Infrastructure;

namespace Shop.Application.ProductsAdmin
{
    [Service]
    public class UpdateProduct
    {
        private IProductManager _productManager;

        public UpdateProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _productManager.GetProductById(request.Id, x => x);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Value = request.Value;
            product.Category = request.Category;
            product.AvRating = request.AvRating;
            product.FullDescription = request.FullDescription;
            product.IsNew = request.IsNew;
            product.IsTrending = request.IsTrending;
            product.IsActive = request.IsActive;
            if(request.ImageAdded == "not")
            {
                product.Image = request.StillImage;
            }
            else
            {
                product.Image = await _productManager.SaveImage(request.Image);

            }

            await _productManager.UpdateProduct(product);

            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                FullDescription = product.FullDescription,
                AvRating = product.AvRating,
                Value = product.Value,
                Category = product.Category,
                Image = product.Image,
                IsTrending = product.IsTrending,
                IsNew = product.IsNew,
                IsActive = product.IsActive
                
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string FullDescription { get; set; }
            public decimal AvRating { get; set; }
            public decimal Value { get; set; }
            public string Category { get; set; }
            public IFormFile Image { get; set; }
            public bool IsTrending { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }
            public string StillImage { get; set; }
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
            public string Category { get; set; }
            public string Image { get; set; }
            public bool IsTrending { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
