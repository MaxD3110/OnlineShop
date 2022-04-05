using Microsoft.AspNetCore.Http;
using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
    [Service]
    public class GetProduct
    {
        private IProductManager _productManager;
        private IStockManager _stockManager;

        public GetProduct(IProductManager productManager, IStockManager stockManager)
        {
            _productManager = productManager;
            _stockManager = stockManager;
        }

        public async Task<ProductViewModel> Do(string name)
        {
            await _stockManager.RetrieveExpiredStockOnHold();

            return _productManager.GetProductByName(name, x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value,
                Image = x.Image,
                Category = x.Category,
                FullDescription = x.FullDescription,
                AvRating = x.AvRating,
                IsNew = x.IsNew,
                IsTrending = x.IsTrending,
                IsActive = x.IsActive,
            Stock = x.Stock.Select(y => new StockViewModel
                {
                    Id = y.Id,
                    Description = y.Description,
                    Qty = y.Qty,
                    Value = y.Value,
                    PropImage = y.PropImage,
                    IsOnSale = y.IsOnSale,
                    IsActive = y.IsActive,
                    Color = y.Color,
                }),
            Specification = x.Specification.Select(z => new SpecificationsViewModel
            {
                Id = z.Id,
                AccumCapacity = z.AccumCapacity,
                Screen = z.Screen,
                BuiltInAccum = z.BuiltInAccum,
                MaxVoltage = z.MaxVoltage,
                VoltageChange = z.VoltageChange,
                BakValue = z.BakValue,
                PuffCol = z.PuffCol,
                Flavour = z.Flavour,
                Vgpg = z.Vgpg,
                Nic = z.Nic,
                NicProp = z.NicProp,
                LiqValue = z.LiqValue,
                MTL = z.MTL,
                Spiral = z.Spiral,
                Obduv = z.Obduv,
                Type = z.Type,
                Amper = z.Amper,
                Length = z.Length,
                Width = z.Width,
                Size = z.Size,
                Weigth = z.Weigth,
                CharghingTime = z.CharghingTime,
            }),
                Review = x.Review.Select(l => new ReviewViewModel
                {
                    Id = l.Id,
                    CommentatorName = l.CommentatorName,
                    Email = l.Email,
                    Comments = l.Comments,
                    Rating = l.Rating,
                    ThisDateTime = l.ThisDateTime,
                    Title = l.Title
                })
            });
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public string Category { get; set; }
            public string FullDescription { get; set; }
            public decimal AvRating { get; set; }
            public string Image { get; set; }
            public string DateTime { get; set; }
            public bool IsTrending { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
            public IEnumerable<SpecificationsViewModel> Specification { get; set; }
            public IEnumerable<ReviewViewModel> Review { get; set; }

        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public string PropImage { get; set; }
            public decimal Value { get; set; }
            public int IsOnSale { get; set; }
            public bool IsActive { get; set; }
            public string Color { get; set; }
        }

        public class SpecificationsViewModel
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

        public class ReviewViewModel
        {
            public int Id { get; set; }
            public string CommentatorName { get; set; }
            public string Email { get; set; }
            public string Title { get; set; }

            public string Comments { get; set; }

            public int Rating { get; set; }

            public string ThisDateTime { get; set; }


        }
    }
}
