namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIEnumerableCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationUserID");
            AddForeignKey("dbo.Customers", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUserID" });
            DropColumn("dbo.Customers", "ApplicationUserID");
        }
    }
}
