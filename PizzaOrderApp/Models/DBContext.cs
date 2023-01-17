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

        public virtual DbSet<OrderTab> OrderTab { get; set; }
        public virtual DbSet<ProdForOrderTab> ProdForOrderTab { get; set; }
        public virtual DbSet<ProductsTab> ProductsTab { get; set; }
        public virtual DbSet<UsersTab> UsersTab { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTab>()
                .Property(e => e.OrderTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderTab>()
                .HasMany(e => e.ProdForOrderTab)
                .WithRequired(e => e.OrderTab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductsTab>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductsTab>()
                .HasMany(e => e.ProdForOrderTab)
                .WithRequired(e => e.ProductsTab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsersTab>()
                .HasOptional(e => e.OrderTab)
                .WithRequired(e => e.UsersTab);
        }
    }
}
