using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Shop.UI.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private const string KeyCart = "cart";
        private const string KeyWish = "wish";
        private const string KeyCompare = "compare";
        private const string KeyCustomerInfo = "customer-info";
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
        public string GetId() => _session.Id;

        public void AddCustomerInformation(CustomerInformation customer)
        {
            var stringObject = JsonConvert.SerializeObject(customer);

            _session.SetString(KeyCustomerInfo, stringObject);
        }

        public void AddProduct(CartProduct cartProduct)
        {
            var cartList = new List<CartProduct>();
            var stringObject = _session.GetString(KeyCart);

            if (!string.IsNullOrEmpty(stringObject))
            {
                cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);
            }

            if (cartList.Any(x => x.StockId == cartProduct.StockId))
            {
                cartList.Find(x => x.StockId == cartProduct.StockId).Qty += cartProduct.Qty;
            }
            else
            {
                cartList.Add(cartProduct);
            }

            stringObject = JsonConvert.SerializeObject(cartList);

            _session.SetString(KeyCart, stringObject);

        }

        public void ClearCart()
        {
            _session.Remove(KeyCart);
        }

        public IEnumerable<TResult> GetCart<TResult>(Func<CartProduct, TResult> selector)
        {
            var stringObject = _session.GetString(KeyCart);

            if (string.IsNullOrEmpty(stringObject))
                return new List<TResult>();

            var cartList = JsonConvert.DeserializeObject<IEnumerable<CartProduct>>(stringObject);
            return cartList.Select(selector);
        }

        public CustomerInformation GetCustomerInformation()
        {
            var stringObject = _session.GetString(KeyCustomerInfo);

            if (string.IsNullOrEmpty(stringObject))
                return null;

            var customerInformation = JsonConvert.DeserializeObject<CustomerInformation>(stringObject);
            return customerInformation;
        }


        public void RemoveProduct(int stockId, int qty)
        {
            var cartList = new List<CartProduct>();

            var stringObject = _session.GetString(KeyCart);

            if (string.IsNullOrEmpty(stringObject)) return;

            cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            if (!cartList.Any(x => x.StockId == stockId)) return;

            var product = cartList.First(x => x.StockId == stockId);
            product.Qty -= qty;
            if(product.Qty <= 0)
            {
                cartList.Remove(product);
            }

            stringObject = JsonConvert.SerializeObject(cartList);

            _session.SetString(KeyCart, stringObject);

        }

        public void AddProductToWish(CartProduct cartProduct)
        {
            var wishList = new List<CartProduct>();
            var stringObject = _session.GetString(KeyWish);

            if (!string.IsNullOrEmpty(stringObject))
            {
                wishList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);
            }

            if (wishList.Any(x => x.StockId == cartProduct.StockId))
            {
                wishList.Find(x => x.StockId == cartProduct.StockId);
            }
            else
            {
                wishList.Add(cartProduct);
            }

            stringObject = JsonConvert.SerializeObject(wishList);

            _session.SetString(KeyWish, stringObject);
        }

        public void ClearWish()
        {
            _session.Remove(KeyWish);
        }

        public IEnumerable<TResult> GetWish<TResult>(Func<CartProduct, TResult> selector)
        {
            var stringObject = _session.GetString(KeyWish);

            if (string.IsNullOrEmpty(stringObject))
                return new List<TResult>();

            var wishList = JsonConvert.DeserializeObject<IEnumerable<CartProduct>>(stringObject);
            return wishList.Select(selector);
        }


        public void RemoveProductFromWish(int stockId)
        {
            var wishList = new List<CartProduct>();

            var stringObject = _session.GetString(KeyWish);

            if (string.IsNullOrEmpty(stringObject)) return;

            wishList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            if (!wishList.Any(x => x.StockId == stockId)) return;

            var product = wishList.First(x => x.StockId == stockId);
            wishList.Remove(product);

            stringObject = JsonConvert.SerializeObject(wishList);

            _session.SetString(KeyWish, stringObject);

        }

        public void AddProductToCompare(CompareProduct cartProduct)
        {
            var compare = new List<CompareProduct>();
            var stringObject = _session.GetString(KeyCompare);

            if (!string.IsNullOrEmpty(stringObject))
            {
                compare = JsonConvert.DeserializeObject<List<CompareProduct>>(stringObject);
            }

            if (compare.Any(x => x.StockId == cartProduct.StockId))
            {
                compare.Find(x => x.StockId == cartProduct.StockId);
            }
            else
            {
                compare.Add(cartProduct);
            }

            stringObject = JsonConvert.SerializeObject(compare);

            _session.SetString(KeyCompare, stringObject);
        }

        public void RemoveProductFromCompare(int stockId)
        {
            var compare = new List<CompareProduct>();

            var stringObject = _session.GetString(KeyCompare);

            if (string.IsNullOrEmpty(stringObject)) return;

            compare = JsonConvert.DeserializeObject<List<CompareProduct>>(stringObject);

            if (!compare.Any(x => x.StockId == stockId)) return;

            var product = compare.First(x => x.StockId == stockId);
            compare.Remove(product);

            stringObject = JsonConvert.SerializeObject(compare);

            _session.SetString(KeyCompare, stringObject);
        }

        public IEnumerable<TResult> GetCompare<TResult>(Func<CompareProduct, TResult> selector)
        {
            var stringObject = _session.GetString(KeyCompare);

            if (string.IsNullOrEmpty(stringObject))
                return new List<TResult>();

            var compare = JsonConvert.DeserializeObject<IEnumerable<CompareProduct>>(stringObject);
            return compare.Select(selector);
        }

        public void ClearCompare()
        {
            _session.Remove(KeyCompare);
        }
    }
}
