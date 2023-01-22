namespace PizzaOrderApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdForOrderTab")]
    public partial class ProdForOrder
    {

        public int ID { get; set; }

        public int OrderID { get; set; }


        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public virtual Order OrderTab { get; set; }

        public virtual Products ProductsTab { get; set; }

        [NotMapped]
        public static List<ProdForOrder> ProdList = new List<ProdForOrder>();
    }
}
