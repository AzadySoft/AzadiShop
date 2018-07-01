using System.ComponentModel.DataAnnotations;

namespace AzadiSoft.OnlineStore.ViewModels
{
    public class PhotoViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public bool Hidden { get; set; }

        public int? Product_ID { get; set; }


    }
}