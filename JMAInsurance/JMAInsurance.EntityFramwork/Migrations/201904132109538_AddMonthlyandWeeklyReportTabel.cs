namespace JMAInsurance.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMonthlyandWeeklyReportTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EMonthlyReports",
                c => new
                    {
                        Id = c.Double(nullable: false),
                        NumberRead = c.Double(nullable: false),
                        ClickThruRate = c.Double(nullable: false),
                        NumberSent = c.Double(nullable: false),
                        AverageQuote = c.Double(nullable: false),
                        ProjectedConversationRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EWeeklyReports",
                c => new
                    {
                        Id = c.Double(nullable: false),
                        NumberRead = c.Double(),
                        ClickThruRate = c.Double(),
                        NumberSent = c.Double(),
                        AverageQuote = c.Double(),
                        ProjectedConversationRate = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EWeeklyReports");
            DropTable("dbo.EMonthlyReports");
        }
    }
}
