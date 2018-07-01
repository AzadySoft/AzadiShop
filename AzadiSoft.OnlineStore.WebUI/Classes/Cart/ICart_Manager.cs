using System.Collections.Generic;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.WebUI.Classes.Cart
{
    public interface ICart_Manager
    {
        IList<CardItem> GetCardItems();

        void AddToCart(int productId, int quantity);

        void RemoveFromCart(int productId);

        void UpdateCount(int productId, int _newCount);

        void ClearCart();
    }
}