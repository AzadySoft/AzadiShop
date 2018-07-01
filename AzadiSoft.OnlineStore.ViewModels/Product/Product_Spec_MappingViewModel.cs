namespace AzadiSoft.OnlineStore.ViewModels
{
    public class Product_Spec_MappingViewModel
    {

        public int ID { get; set; }

        public int Product_ID { get; set; }

        public string Product_Title { get; set; }

        public int Spec_ID { get; set; }

        public string Spec_Title { get; set; }

        public int SpecOption_ID { get; set; }

        public string SpecOption_Title { get; set; }

        public string CustomValue { get; set; }

        public bool Hidden { get; set; }


    }
}