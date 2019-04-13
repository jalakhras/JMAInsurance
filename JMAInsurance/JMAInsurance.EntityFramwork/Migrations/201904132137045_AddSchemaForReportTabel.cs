namespace JMAInsurance.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchemaForReportTabel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EWeeklyReports", newName: "WeeklyReports");
            MoveTable(name: "dbo.EMonthlyReports", newSchema: "Insurance");
            MoveTable(name: "dbo.WeeklyReports", newSchema: "Insurance");
        }
        
        public override void Down()
        {
            MoveTable(name: "Insurance.WeeklyReports", newSchema: "dbo");
            MoveTable(name: "Insurance.EMonthlyReports", newSchema: "dbo");
            RenameTable(name: "dbo.WeeklyReports", newName: "EWeeklyReports");
        }
    }
}
