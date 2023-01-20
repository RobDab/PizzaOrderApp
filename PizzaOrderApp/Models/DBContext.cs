using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PizzaOrderApp.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Order> OrderTab { get; set; }
        public virtual DbSet<ProdForOrder> ProdForOrderTab { get; set; }
        public virtual DbSet<Products> ProductsTab { get; set; }
        public virtual DbSet<Users> UsersTab { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.OrderTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.ProdForOrderTab)
                .WithRequired(e => e.OrderTab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.ProdForOrderTab)
                .WithRequired(e => e.ProductsTab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.OrderTab)
                .WithRequired(e => e.UsersTab);
        }
    }
}
