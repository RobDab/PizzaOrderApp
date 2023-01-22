namespace PizzaOrderApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderTab")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            ProdForOrderTab = new HashSet<ProdForOrder>();
        }

        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "money")]
        public decimal OrderTotal { get; set; }

        [StringLength(50)]
        public string OrderAdress { get; set; }

        public bool? Delivered { get; set; }

        public virtual Users UsersTab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdForOrder> ProdForOrderTab { get; set; }

        
    }
}
