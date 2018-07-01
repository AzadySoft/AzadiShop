using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using AzadiSoft.OnlineStore.Resources;
using AzadiSoft.OnlineStore.ServiceLayer;
using AzadiSoft.OnlineStore.WebUI.Classes.Cart;

namespace AzadiSoft.OnlineStore.WebUI.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICart_Manager _cartManager;
        private readonly IProduct_Service _productService;

        public CartController(ICart_Manager cartManager, IProduct_Service productService)
        {
            _cartManager = cartManager;
            _productService = productService;
        }

        // GET: Cart
        public ActionResult Index()
        {
            var items = _cartManager.GetCardItems();

            foreach (var cardItem in items)
            {
                var product = _productService.GetById(cardItem.Product_ID);
                cardItem.Product_Title = product.Title;
                cardItem.UnitPrice = product.Price;
                cardItem.TotalPrice = cardItem.UnitPrice * cardItem.Quantity;
            }

            return View(items);
        }

        public ActionResult AddToCart(int productId, int count)
        {

            var product = _productService.GetViewModel(productId);

            if (count <= product.StockQuantity)
            {
                _cartManager.AddToCart(productId, count);

                return SuccessResult();

            }
            else
            {
                return ErrorResult(Messages.OutOfStockQuantity);
            }

        }

        public ActionResult RemoveFromCart(int productId)
        {
            _cartManager.RemoveFromCart(productId);

            return SuccessResult();

        }

        public ActionResult UpdateCartItem(int productId, int count)
        {
            var product = _productService.GetViewModel(productId);

            if (count <= product.StockQuantity)
            {
                _cartManager.UpdateCount(productId, count);

                return SuccessResult();
            }
            else
            {
                return ErrorResult(Messages.OutOfStockQuantity);
            }

        }

        public ActionResult ClearCart()
        {
            _cartManager.ClearCart();

            return SuccessResult();
        }

        public ActionResult CheckOut()
        {
            var cartItems = _cartManager.GetCardItems();

            foreach (var item in cartItems)
            {
                var product = _productService.GetById(item.Product_ID);
                if (product.StockQuantity < item.Quantity)
                {
                    return ErrorResult(Messages.OutOfStockQuantity + " - محصول: " + product.Title);
                }
            }

            foreach (var item in cartItems)
            {
                var product = _productService.GetById(item.Product_ID);
                product.StockQuantity -= item.Quantity;
                _productService.Update(product);
            }

            _cartManager.ClearCart();

            return SuccessResult();
        }
    }
}