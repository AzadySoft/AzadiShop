using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AzadiSoft.OnlineStore.Resources;

namespace AzadiSoft.OnlineStore.ViewModels
{
    public class ProductListViewModel
    {
        public IList<ProductViewModel> Products { get; set; }

        public ProductViewModel SampleModel { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "ProductTitle")]
        public string Product_Title { get; set; }

        public ProductListViewModel()
        {
            Products = new List<ProductViewModel>();
            SampleModel = new ProductViewModel();
        }
    }
}