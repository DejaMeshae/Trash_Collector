namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            DropColumn("dbo.Customers", "ApplicationId");
            DropColumn("dbo.Customers", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ApplicationUserID", c => c.String());
            AddColumn("dbo.Customers", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationId");
            AddForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
    }
}
