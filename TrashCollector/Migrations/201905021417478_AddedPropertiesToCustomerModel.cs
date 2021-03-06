namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertiesToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "TempSuspendStart", c => c.String());
            AddColumn("dbo.Customers", "TempSuspendEnd", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "TempSuspendEnd");
            DropColumn("dbo.Customers", "TempSuspendStart");
        }
    }
}
