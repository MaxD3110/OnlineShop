using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;

namespace Shop.Application.Compare
{

    [Service]
    public class AddToCompare
    {
        private ISessionManager _sessionManager;
        private IStockManager _stockManager;
        private ISpecificationManager _specificationManager;

        public AddToCompare(ISessionManager sessionManager, IStockManager stockManager, ISpecificationManager specificationManager)
        {
            _sessionManager = sessionManager;
            _stockManager = stockManager;
            _specificationManager = specificationManager;
        }

        public class Request
        {
            public string Key{ get; set; }
        }

        public bool Do(Request request)
        {
            string[] ids = request.Key.Split(new char[] { ',' });
            var stock = _stockManager.GetStockWithProduct(Convert.ToInt32(ids[0])); 
            var spec = _specificationManager.GetSpecWithProduct(Convert.ToInt32(ids[1]));
            var compare = new CompareProduct()
            {
                ProductId = stock.ProductId,
                ProductName = stock.Product.Name,
                StockId = stock.Id,
                Value = stock.Value - (stock.Value * (stock.IsOnSale) / 100),
                ProductDescription = stock.Product.Description,
                Image = stock.PropImage,
                Description = stock.Description,
                Sqty = stock.Qty,
                SpecId = spec.Id,
                AccumCapacity = spec.AccumCapacity,
                Screen = spec.Screen,
                BuiltInAccum = spec.BuiltInAccum,
                MaxVoltage = spec.MaxVoltage,
                VoltageChange = spec.VoltageChange,
                BakValue = spec.BakValue,
                PuffCol = spec.PuffCol,
                Flavour = spec.Flavour,
                Vgpg = spec.Vgpg,
                Nic = spec.Nic,
                NicProp = spec.NicProp,
                LiqValue = spec.LiqValue,
                MTL = spec.MTL,
                Spiral = spec.Spiral,
                Obduv = spec.Obduv,
                Type = spec.Type,
                Amper = spec.Amper,
                Length = spec.Length,
                Width = spec.Width,
                Size = spec.Size,
                Weigth = spec.Weigth,
                CharghingTime = spec.CharghingTime,
            };

            _sessionManager.AddProductToCompare(compare);

            return true;
        }
    }
}
