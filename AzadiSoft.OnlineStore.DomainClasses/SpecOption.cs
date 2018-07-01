namespace AzadiSoft.OnlineStore.DomainClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpecOption")]
    public partial class SpecOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpecOption()
        {
            Product_Spec_Mapping = new HashSet<Product_Spec_Mapping>();
        }

        public int ID { get; set; }

        public int Spec_ID { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        public string Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Spec_Mapping> Product_Spec_Mapping { get; set; }

        public virtual Spec Spec { get; set; }
    }
}
