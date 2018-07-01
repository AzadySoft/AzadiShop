using System.ComponentModel.DataAnnotations;
using AzadiSoft.OnlineStore.Resources;

namespace AzadiSoft.OnlineStore.ViewModels
{
    public class CardItem
    {
        public int ID { get; set; }

        public int Product_ID { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "ProductTitle")]
        public string Product_Title { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "TotalPrice")]
        public decimal TotalPrice { get; set; }
    }
}