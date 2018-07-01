namespace AzadiSoft.OnlineStore.DomainClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Spec_Mapping
    {
        public int ID { get; set; }

        public int Product_ID { get; set; }

        public int Spec_ID { get; set; }

        public int SpecOption_ID { get; set; }

        public string CustomValue { get; set; }

        public bool Hidden { get; set; }

        public virtual Product Product { get; set; }

        public virtual Spec Spec { get; set; }

        public virtual SpecOption SpecOption { get; set; }
    }
}
