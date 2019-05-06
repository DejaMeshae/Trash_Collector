namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyApplicationUserToEmployeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ApplicationUserID");
            AddForeignKey("dbo.Employees", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationUserID" });
            DropColumn("dbo.Employees", "ApplicationUserID");
        }
    }
}
