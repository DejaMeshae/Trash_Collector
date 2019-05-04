namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBillAmountInCustomersModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BillAmount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BillAmount");
        }
    }
}
