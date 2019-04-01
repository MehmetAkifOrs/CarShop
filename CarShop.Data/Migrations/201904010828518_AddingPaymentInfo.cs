namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPaymentInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SenderName", c => c.String());
            AddColumn("dbo.Orders", "IdNumber", c => c.String());
            AddColumn("dbo.Orders", "BankName", c => c.String());
            AddColumn("dbo.Orders", "BankIban", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "BankIban");
            DropColumn("dbo.Orders", "BankName");
            DropColumn("dbo.Orders", "IdNumber");
            DropColumn("dbo.Orders", "SenderName");
        }
    }
}
