namespace AzadiSoft.OnlineStore.DomainClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Photos = new HashSet<Photo>();
            Product_Spec_Mapping = new HashSet<Product_Spec_Mapping>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public string FullText { get; set; }

        public DateTime DateCreated { get; set; }

        public int VisitCount { get; set; }

        public int StockQuantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Spec_Mapping> Product_Spec_Mapping { get; set; }

        public decimal Price { get; set; }
    }
}
