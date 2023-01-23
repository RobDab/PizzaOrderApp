namespace PizzaOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredOrderTotal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderTab", "OrderAdress", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderTab", "OrderAdress", c => c.String(maxLength: 50));
        }
    }
}
