using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Shop.Application.Compare;
using Shop.Application.Wishlist;
using System.Linq;

namespace Shop.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private GetCart _getCart;
        private GetWish _getWish;
        private GetCompare _getCompare;

        public CartViewComponent(GetCart getCart, GetWish getWish, GetCompare getCompare)
        {
            _getCart = getCart;
            _getWish = getWish;
            _getCompare = getCompare;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            if(view == "Small")
            {
                var totalValue = _getCart.Do().Sum(x => x.RealValue * x.Qty).ToString("0.00");
                return View(view, $"{totalValue}");
            }
            else if(view == "Medium")
            {
                return View(view, _getCart.Do());
            }
            else if (view == "SmallWish")
            {
                var totalValue = _getWish.Do().Count();
                return View(view, totalValue);
            }
            else if (view == "DefaultWish")
            {
                return View(view, _getWish.Do());
            }
            else if (view == "MediumCompare")
            {
                return View(view, _getCompare.Do());
            }
            return View(view, _getCart.Do());
        }
    }
}
