using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public decimal AvRating { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string DateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrending { get; set; }
        public bool IsNew { get; set; }


        public ICollection<Review> Review { get; set; }
        public ICollection<Specification> Specification { get; set; }
        public ICollection<Stock> Stock { get; set; }
    }
}
