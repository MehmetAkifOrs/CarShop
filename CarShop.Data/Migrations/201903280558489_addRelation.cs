namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carts", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.Carts", name: "IX_Product_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Carts", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.Carts", name: "ProductId", newName: "Product_Id");
        }
    }
}
