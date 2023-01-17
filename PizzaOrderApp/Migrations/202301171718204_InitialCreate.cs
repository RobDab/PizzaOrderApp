namespace PizzaOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderTab",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        OrderTotal = c.Decimal(nullable: false, storeType: "money"),
                        OrderAdress = c.String(maxLength: 50),
                        Delivered = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.UsersTab", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.ProdForOrderTab",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductsTab", t => t.ProductID)
                .ForeignKey("dbo.OrderTab", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductsTab",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        URLImg = c.String(nullable: false, maxLength: 20),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        DeliveryTime = c.Int(nullable: false),
                        Ingredients = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.UsersTab",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderTab", "OrderID", "dbo.UsersTab");
            DropForeignKey("dbo.ProdForOrderTab", "OrderID", "dbo.OrderTab");
            DropForeignKey("dbo.ProdForOrderTab", "ProductID", "dbo.ProductsTab");
            DropIndex("dbo.ProdForOrderTab", new[] { "ProductID" });
            DropIndex("dbo.ProdForOrderTab", new[] { "OrderID" });
            DropIndex("dbo.OrderTab", new[] { "OrderID" });
            DropTable("dbo.UsersTab");
            DropTable("dbo.ProductsTab");
            DropTable("dbo.ProdForOrderTab");
            DropTable("dbo.OrderTab");
        }
    }
}
