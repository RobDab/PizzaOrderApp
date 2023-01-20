namespace PizzaOrderApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersTab")]
    public partial class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string Role { get; set; }


        public bool RememberMe { get; set; }

        public virtual Order OrderTab { get; set; }
    }
}
