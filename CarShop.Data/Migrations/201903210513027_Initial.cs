namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Piece = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropTable("dbo.Carts");
        }
    }
}
