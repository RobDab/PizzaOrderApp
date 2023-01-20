namespace PizzaOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolPersistenceInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersTab", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersTab", "RememberMe");
        }
    }
}
