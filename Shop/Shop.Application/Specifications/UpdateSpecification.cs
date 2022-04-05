using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Application.Specifications
{
    [Service]
    public class UpdateSpecification
    {
        private ISpecificationManager _specificationManager;

        public UpdateSpecification(ISpecificationManager specificationManager)
        {
            _specificationManager = specificationManager;
        }

        public async Task<Response> Do(Request request)
        {
            var specificationList = new List<Specification>();

            foreach (var specification in request.Specification)
            {
                specificationList.Add(new Specification
                {
                    Id = specification.Id,
                    ProductId = specification.ProductId,
                    AccumCapacity = specification.AccumCapacity,
                    Screen = specification.Screen,
                    BuiltInAccum = specification.BuiltInAccum,
                    MaxVoltage = specification.MaxVoltage,
                    VoltageChange = specification.VoltageChange,
                    BakValue = specification.BakValue,
                    PuffCol = specification.PuffCol,
                    Flavour = specification.Flavour,
                    Vgpg = specification.Vgpg,
                    Nic = specification.Nic,
                    NicProp = specification.NicProp,
                    LiqValue = specification.LiqValue,
                    MTL = specification.MTL,
                    Spiral = specification.Spiral,
                    Obduv = specification.Obduv,
                    Type = specification.Type,
                    Amper = specification.Amper,
                    Length = specification.Length,
                    Width = specification.Width,
                    Size = specification.Size,
                    Weigth = specification.Weigth,
                    CharghingTime = specification.CharghingTime,

                });
            }

            await _specificationManager.UpdateSpecificationRange(specificationList);

            return new Response
            {
                Specification = request.Specification
            };
        }

        public class SpecificationViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
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

        public class Request
        {
            public IEnumerable<SpecificationViewModel> Specification { get; set; }
        }

        public class Response
        {
            public IEnumerable<SpecificationViewModel> Specification { get; set; }
        }
    }
}
