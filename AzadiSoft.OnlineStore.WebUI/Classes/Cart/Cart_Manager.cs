using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using AzadiSoft.OnlineStore.Resources;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.WebUI.Classes.Cart
{
    public class Cart_Manager : ICart_Manager
    {

        public HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public IList<CardItem> GetCardItems()
        {
            var cardItems = Session[Consts.CardItems] as IList<CardItem>;

            if (cardItems == null)
            {
                cardItems = new List<CardItem>();
                Session[Consts.CardItems] = cardItems;
            }

            return cardItems;
        }

        public void AddToCart(int productId, int quantity)
        {

            var cart = GetCardItems();
            var item = GetCardByProduct(productId);
            if (item == null)
            {
                item = new CardItem() {Product_ID = productId, Quantity = quantity};
                cart.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        private CardItem GetCardByProduct(int productId)
        {
            var cart = GetCardItems();
            return cart.SingleOrDefault(x => x.Product_ID == productId);
        }

        public void RemoveFromCart(int productId)
        {
            var item = GetCardByProduct(productId);
            GetCardItems().Remove(item);
        }

        public void UpdateCount(int productId, int _newCount)
        {
            var item = GetCardByProduct(productId);

            item.Quantity = _newCount;

            /*var cart = GetCardItems();

            var index = cart.IndexOf(item);


            cart[index] = item;

            Session[Consts.CardItems] = cart;*/


        }

        public void ClearCart()
        {
            var cart = GetCardItems();

            cart.Clear();
        }
    }
}