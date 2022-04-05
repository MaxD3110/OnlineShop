using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System.Threading.Tasks;

namespace Shop.Application.Specifications
{
    [Service]
    public class AddSpecification
    {
        private ISpecificationManager _specificationManager;

        public AddSpecification(ISpecificationManager specificationManager)
        {
            _specificationManager = specificationManager;
        }

        public async Task<Response> Do(Request request)
        {
            var specification = new Specification
            {
                ProductId = request.ProductId,
                AccumCapacity = request.AccumCapacity,
                Screen = request.Screen,
                BuiltInAccum = request.BuiltInAccum,
                MaxVoltage = request.MaxVoltage,
                VoltageChange = request.VoltageChange,
                BakValue = request.BakValue,
                PuffCol = request.PuffCol,
                Flavour = request.Flavour,
                Vgpg = request.Vgpg,
                Nic = request.Nic,
                NicProp = request.NicProp,
                LiqValue = request.LiqValue,
                MTL = request.MTL,
                Spiral = request.Spiral,
                Obduv = request.Obduv,
                Type = request.Type,
                Amper = request.Amper,
                Length = request.Length,
                Width = request.Width,
                Size = request.Size,
                Weigth = request.Weigth,
                CharghingTime = request.CharghingTime,
            };

            await _specificationManager.AddSpecification(specification);

            return new Response
            {
                Id = specification.Id,
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
            };
        }
        public class Request
        {
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

        public class Response
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
    }
}
