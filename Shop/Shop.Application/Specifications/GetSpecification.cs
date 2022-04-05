using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Specifications
{
    [Service]
    public class GetSpecification
    {
        private IProductManager _poductManager;

        public GetSpecification(IProductManager poductManager)
        {
            _poductManager = poductManager;
        }
        public IEnumerable<ProductViewModel> Do()
        {
            return _poductManager.GetProductsWithSpecification(x => new ProductViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Specification = x.Specification.Select(y => new SrecificationViewModel
                {
                    Id = y.Id,
                    AccumCapacity = y.AccumCapacity,
                    Screen = y.Screen,
                    BuiltInAccum = y.BuiltInAccum,
                    MaxVoltage = y.MaxVoltage,
                    VoltageChange = y.VoltageChange,
                    BakValue = y.BakValue,
                    PuffCol = y.PuffCol,
                    Flavour = y.Flavour,
                    Vgpg = y.Vgpg,
                    Nic = y.Nic,
                    NicProp = y.NicProp,
                    LiqValue = y.LiqValue,
                    MTL = y.MTL,
                    Spiral = y.Spiral,
                    Obduv = y.Obduv,
                    Type = y.Type,
                    Amper = y.Amper,
                    Length = y.Length,
                    Width = y.Width,
                    Size = y.Size,
                    Weigth = y.Weigth,
                    CharghingTime = y.CharghingTime,
                })
            });
        }

        public class SrecificationViewModel
        {
            public int Id { get; set; }
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

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public IEnumerable<SrecificationViewModel> Specification { get; set; }
        }
    }
}
