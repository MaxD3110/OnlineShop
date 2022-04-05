using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Value { get; set; }
        public string Color { get; set; }
        public int IsOnSale { get; set; }
        public bool IsActive { get; set; }
        public string PropImage { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<OrderStock> OrderStocks{ get; set; }
    }
}
