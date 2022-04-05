using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int StockId { get; set; }
        public int IsOnSale { get; set; }
        public int Qty { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Sqty { get; set; }
    }
}
