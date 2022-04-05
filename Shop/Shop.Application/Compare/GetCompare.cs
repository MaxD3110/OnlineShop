using Shop.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Compare
{
    [Service]
    public class GetCompare
    {
        private ISessionManager _sessionManager;

        public GetCompare(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public decimal RealValue { get; set; }
            public int Qty { get; set; }
            public int StockId { get; set; }
            public string PropImage { get; set; }
            public string ProductDescription { get; set; }
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


        public IEnumerable<Response> Do()
        {
            return _sessionManager.GetCompare(x => new Response
            {
                Name = x.ProductName,
                Value = x.Value.GetValueString(),
                RealValue = x.Value,
                StockId = x.StockId,
                Qty = x.Qty,
                Sqty = x.Sqty,
                PropImage = x.Image,
                Description = x.Description,
                ProductDescription = x.ProductDescription,
                SpecId = x.SpecId,
                    AccumCapacity = x.AccumCapacity,
                    Screen = x.Screen,
                    BuiltInAccum = x.BuiltInAccum,
                    MaxVoltage = x.MaxVoltage,
                    VoltageChange = x.VoltageChange,
                    BakValue = x.BakValue,
                    PuffCol = x.PuffCol,
                    Flavour = x.Flavour,
                    Vgpg = x.Vgpg,
                    Nic = x.Nic,
                    NicProp = x.NicProp,
                    LiqValue = x.LiqValue,
                    MTL = x.MTL,
                    Spiral = x.Spiral,
                    Obduv = x.Obduv,
                    Type = x.Type,
                    Amper = x.Amper,
                    Length = x.Length,
                    Width = x.Width,
                    Size = x.Size,
                    Weigth = x.Weigth,
                    CharghingTime = x.CharghingTime,
            });
        }

       
    }
}
