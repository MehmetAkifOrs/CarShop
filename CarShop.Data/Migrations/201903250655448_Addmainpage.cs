namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmainpage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainPages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MainPagePhoto = c.String(),
                        MainPageHeader = c.String(),
                        MainPageDescription = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MainPages");
        }
    }
}
