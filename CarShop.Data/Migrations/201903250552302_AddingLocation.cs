namespace CarShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Orders", new[] { "DistrictId" });
            RenameColumn(table: "dbo.Orders", name: "CityId", newName: "City_Id");
            RenameColumn(table: "dbo.Orders", name: "CountryId", newName: "Country_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_CountryId", newName: "IX_Country_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_CityId", newName: "IX_City_Id");
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryId = c.Guid(),
                        CityId = c.Guid(),
                        DistrictId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId);
            
            DropColumn("dbo.Orders", "DistrictId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DistrictId", c => c.Guid());
            DropForeignKey("dbo.Locations", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Locations", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Locations", "CityId", "dbo.Cities");
            DropIndex("dbo.Locations", new[] { "DistrictId" });
            DropIndex("dbo.Locations", new[] { "CityId" });
            DropIndex("dbo.Locations", new[] { "CountryId" });
            DropTable("dbo.Locations");
            RenameIndex(table: "dbo.Orders", name: "IX_City_Id", newName: "IX_CityId");
            RenameIndex(table: "dbo.Orders", name: "IX_Country_Id", newName: "IX_CountryId");
            RenameColumn(table: "dbo.Orders", name: "Country_Id", newName: "CountryId");
            RenameColumn(table: "dbo.Orders", name: "City_Id", newName: "CityId");
            CreateIndex("dbo.Orders", "DistrictId");
            AddForeignKey("dbo.Orders", "DistrictId", "dbo.Districts", "Id");
        }
    }
}
