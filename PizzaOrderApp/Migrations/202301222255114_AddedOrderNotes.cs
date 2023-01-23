namespace PizzaOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderTab", "OrderNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderTab", "OrderNotes");
        }
    }
}
