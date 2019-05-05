namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatepickertootherproperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StopPickUp", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Customers", "TempSuspendStart", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Customers", "TempSuspendEnd", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "TempSuspendEnd", c => c.String());
            AlterColumn("dbo.Customers", "TempSuspendStart", c => c.String());
            AlterColumn("dbo.Customers", "StopPickUp", c => c.String());
        }
    }
}
