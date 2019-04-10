namespace JMAInsurance.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAddressTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Insurance.Address", "CityId", "Lookups.City");
            DropForeignKey("Insurance.Address", "CountryId", "Lookups.Country");
            DropIndex("Insurance.Address", new[] { "CountryId" });
            DropIndex("Insurance.Address", new[] { "CityId" });
            AddColumn("Insurance.Address", "City", c => c.String());
            AddColumn("Insurance.Address", "Country", c => c.String());
            DropColumn("Insurance.Address", "CountryId");
            DropColumn("Insurance.Address", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("Insurance.Address", "CityId", c => c.Int(nullable: false));
            AddColumn("Insurance.Address", "CountryId", c => c.Int(nullable: false));
            DropColumn("Insurance.Address", "Country");
            DropColumn("Insurance.Address", "City");
            CreateIndex("Insurance.Address", "CityId");
            CreateIndex("Insurance.Address", "CountryId");
            AddForeignKey("Insurance.Address", "CountryId", "Lookups.Country", "Id", cascadeDelete: true);
            AddForeignKey("Insurance.Address", "CityId", "Lookups.City", "Id", cascadeDelete: true);
        }
    }
}
