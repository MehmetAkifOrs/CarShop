namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPieceEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "piece", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "piece");
        }
    }
}
