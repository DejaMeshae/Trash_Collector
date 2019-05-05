namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneTimePickUpproperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "OneTimePickUpDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OneTimePickUpDate");
        }
    }
}
