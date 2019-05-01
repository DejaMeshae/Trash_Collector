namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreRecordToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpdate", c => c.String());
            AddColumn("dbo.Customers", "StopPickUp", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Customers", "StopPickUp");
            DropColumn("dbo.Customers", "PickUpdate");
        }
    }
}
