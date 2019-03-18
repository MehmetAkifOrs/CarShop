namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ProductId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Products", "Photo2");
            DropColumn("dbo.Products", "Photo3");
            DropColumn("dbo.Products", "Photo4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Photo4", c => c.String());
            AddColumn("dbo.Products", "Photo3", c => c.String());
            AddColumn("dbo.Products", "Photo2", c => c.String());
            DropForeignKey("dbo.Photos", "ProductId", "dbo.Products");
            DropIndex("dbo.Photos", new[] { "ProductId" });
            DropTable("dbo.Photos");
        }
    }
}
