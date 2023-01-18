namespace PizzaOrderApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdForOrderTab")]
    public partial class ProdForOrderTab
    {
        
        public int ID { get; set; }

        public int OrderID { get; set; }


        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public virtual OrderTab OrderTab { get; set; }

        public virtual ProductsTab ProductsTab { get; set; }
    }
}
