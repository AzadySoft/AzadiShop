using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AzadiSoft.OnlineStore.Resources;

namespace AzadiSoft.OnlineStore.ViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "ProductTitle")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "Description")]
        public string Description { get; set; }

        public string FullText { get; set; }

        public DateTime DateCreated { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "DateCreated_Persian")]
        public string DateCreated_Persian { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "VisitCount")]
        public int VisitCount { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "StockQuantity")]
        public int StockQuantity { get; set; }

        [Display(ResourceType = typeof(Messages), Name = "Price")]

        public decimal Price { get; set; }

        public IList<Product_Spec_MappingViewModel> ProductSpecMappings { get; set; }

        public IList<PhotoViewModel> Photos { get; set; }

        public string FirstPhotoUrl
        {
            get { return Photos.Any() ? Photos[0].ImageURL : Consts.NoImageUrl; }
        }

        public ProductViewModel()
        {
            ProductSpecMappings = new List<Product_Spec_MappingViewModel>();
            Photos = new List<PhotoViewModel>();
        }

    }
}