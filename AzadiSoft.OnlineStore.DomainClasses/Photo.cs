namespace AzadiSoft.OnlineStore.DomainClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photo")]
    public partial class Photo
    {
        public int ID { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        [StringLength(512)]
        public string ImageURL { get; set; }

        public bool Hidden { get; set; }

        public int? Product_ID { get; set; }

        public virtual Product Product { get; set; }
    }
}
