namespace PizzaOrderApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductsTab")]
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            ProdForOrderTab = new HashSet<ProdForOrder>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        
        [StringLength(20)]
        public string URLImg { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int DeliveryTime { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdForOrder> ProdForOrderTab { get; set; }
    }
}
