using Shop.Domain.Infrastructure;

namespace Shop.Application.ProductsAdmin
{
    [Service]
    public class GetProduct
    {
        private IProductManager _productManager;

        public GetProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public ProductViewModel Do(int id) =>
            _productManager.GetProductById(id, x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                FullDescription = x.FullDescription,
                AvRating = x.AvRating,
                Image = x.Image,
                Value = x.Value,
                Category = x.Category,
                IsTrending = x.IsTrending,
                IsNew = x.IsNew,
                IsActive = x.IsActive,
                DateTime = x.DateTime
            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string FullDescription { get; set; }
            public decimal AvRating { get; set; }
            public string Image { get; set; }
            public decimal Value { get; set; }
            public string Category { get; set; }
            public string DateTime { get; set; }
            public bool IsTrending { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }

        }
    }
}
