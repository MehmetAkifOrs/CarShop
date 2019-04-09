namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoCancel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Photo", c => c.String(nullable: false));
        }
    }
}
