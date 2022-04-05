
namespace Shop.Domain.Models
{
    public class CompareProduct
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
        public int SpecId { get; set; }
        public string AccumCapacity { get; set; }

        public string Screen { get; set; }
        public string BuiltInAccum { get; set; }

        public string MaxVoltage { get; set; }

        public string VoltageChange { get; set; }

        public string BakValue { get; set; }
        //Expandable
        public string PuffCol { get; set; }
        //Liquids
        public string Flavour { get; set; }
        public string Vgpg { get; set; }

        public string Nic { get; set; }

        public string NicProp { get; set; }

        public string LiqValue { get; set; }

        //Atomizer
        public string MTL { get; set; }
        public string Spiral { get; set; }

        public string Obduv { get; set; }

        public string Type { get; set; }

        //Battery

        public string Amper { get; set; }
        public string Length { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Weigth { get; set; }
        public string CharghingTime { get; set; }
    }
}
