namespace JMAInsurance.EntityFramwork.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EditVehiclesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Insurance.Vehicles", "YearId", "Lookups.Years");
            DropIndex("Insurance.Vehicles", new[] { "YearId" });
            AddColumn("Insurance.Vehicles", "Year", c => c.Double(nullable: false));
            DropColumn("Insurance.Vehicles", "YearId");
            DropTable("Lookups.Years");
        }
        
        public override void Down()
        {
            CreateTable(
                "Lookups.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        year = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Insurance.Vehicles", "YearId", c => c.Int(nullable: false));
            DropColumn("Insurance.Vehicles", "Year");
            CreateIndex("Insurance.Vehicles", "YearId");
            AddForeignKey("Insurance.Vehicles", "YearId", "Lookups.Years", "Id", cascadeDelete: true);
        }
    }
}
