namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartPickUpServicesInCustomersModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartPickUp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "StartPickUp");
        }
    }
}
