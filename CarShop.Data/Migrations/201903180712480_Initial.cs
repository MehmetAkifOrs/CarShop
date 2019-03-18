namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "ProductId", "dbo.Products");
            DropIndex("dbo.Photos", new[] { "ProductId" });
            AlterColumn("dbo.Photos", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Photos", "ProductId", c => c.Guid());
            CreateIndex("dbo.Photos", "ProductId");
            AddForeignKey("dbo.Photos", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "ProductId", "dbo.Products");
            DropIndex("dbo.Photos", new[] { "ProductId" });
            AlterColumn("dbo.Photos", "ProductId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Photos", "Name", c => c.String());
            CreateIndex("dbo.Photos", "ProductId");
            AddForeignKey("dbo.Photos", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
