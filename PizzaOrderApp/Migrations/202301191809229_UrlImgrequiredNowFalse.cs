namespace PizzaOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrlImgrequiredNowFalse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductsTab", "URLImg", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductsTab", "URLImg", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
