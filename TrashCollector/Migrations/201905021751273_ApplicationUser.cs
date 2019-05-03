namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ApplicationId", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "ApplicationUserID", c => c.String());
            CreateIndex("dbo.Customers", "ApplicationId");
            AddForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            DropColumn("dbo.Customers", "ApplicationUserID");
            DropColumn("dbo.Customers", "ApplicationId");
        }
    }
}
